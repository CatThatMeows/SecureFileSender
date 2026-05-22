using FileSender.Core.Client;
using FileSender.Core.Network;
using FileSender.Core.Packets;
using System.Reflection;

namespace FileSenderTesterApp
{
    public partial class Main : Form
    {
        private readonly object SyncObject = new object();
        private readonly PacketHandler packetHandler = new TesterClientPacketHandler();
        private TestConnection con;
        private string lastResponse = String.Empty;

        public static Dictionary<string, string> PacketTemplates = new();

        public Main()
        {
            InitializeComponent();
            sendReqBTN.Enabled = false;
            connectedLB.Text = "DISCONNECTED";
            connectedLB.ForeColor = Color.Red;
        }

        private async void connectBTN_Click(object sender, EventArgs e)
        {
            con = new TestConnection();
            bool connected = await con.Connect(IPTB.Text.Split(':')[0], int.Parse(IPTB.Text.Split(':')[1]), packetHandler);
            if (connected)
            {
                Connected();
                _ = con.ReceiveData();
            }
            else
                MessageBox.Show("Failed to connect to host.");
        }

        private void Intercept(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                string input = (string)sender;
                if(lastResponse != input)
                {
                    lastResponse = input;
                    responseTB.Text = lastResponse;
                }
            }
            else
                lastResponse = "Empty response";
        }

        private void Connected()
        {
            con.OnDisconnected += OnDisconnected;
            ((TesterClientPacketHandler)packetHandler).onMessageReceived += Intercept;

            sendReqBTN.Enabled = true;
            connectedLB.Text = "CONNECTED";
            connectedLB.ForeColor = Color.Green;
        }
        private void OnDisconnected(object? sender, EventArgs e)
        {
            if (con.OnDisconnected != null)
                con.OnDisconnected -= OnDisconnected;

            if (((TesterClientPacketHandler)packetHandler).onMessageReceived != null)
                ((TesterClientPacketHandler)packetHandler).onMessageReceived -= Intercept;

            sendReqBTN.Enabled = false;
            connectedLB.Text = "DISCONNECTED";
            connectedLB.ForeColor = Color.Red;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PacketTemplates.Clear();
            foreach (PacketType pt in Enum.GetValues<PacketType>())
            {
                packetTypesCB.Items.Add(pt);

                Assembly asm = typeof(AuthPacket).Assembly;
                Type? type = asm.GetType($"FileSender.Core.Packets.{pt.ToString()}");

                if (type == null)
                    continue;

                FieldInfo? field = type.GetField("Template");
                string? template = field?.GetValue(null)?.ToString();

                if (template != null)
                {
                    PacketTemplates[pt.ToString()] = template;
                }
            }
        }
        private void packetTypesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(packetTypesCB.SelectedItem.ToString()))
                requestBodyTB.Text = PacketTemplates[packetTypesCB.SelectedItem.ToString()];
        }

        private void sendReqBTN_Click(object sender, EventArgs e)
        {
            PacketType pt = (PacketType)Enum.Parse(typeof(PacketType), packetTypesCB.SelectedItem.ToString());
            string rqbody = requestBodyTB.Text;
            int packetValue = (int)packetsToSendNSB.Value;
            Task.Run(() =>
            {
                Task[] tasks = new Task[packetValue];
                for (int i = 0; i < packetValue; i++)
                {
                    tasks[i] = con.SendTestCMD(rqbody, pt);
                }
            });
        }
    }
}
