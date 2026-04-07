namespace FileSender.Core.Network.Server
{
    public class ClientList
    {
        private static ClientList _CL = new ClientList();
        private object lockObject = new object();
        public static ClientList CL
        {
            get
            {
                return _CL;
            }
        }
        private List<WeakReference<ClientNode>> Clients = new List<WeakReference<ClientNode>>();

        public void AddClient(ClientNode node)
        {
            lock (lockObject)
            {
                WeakReference<ClientNode> cn = new WeakReference<ClientNode>(node);
                Clients.Add(cn);
            }
        }

        public ClientNode GetNode(Guid ID)
        {
            return null;
        }

        public void RefreshList()
        {
            lock (lockObject)
            {
                List<WeakReference<ClientNode>> ToRemove = new List<WeakReference<ClientNode>>();
                foreach (WeakReference<ClientNode> node in Clients)
                {
                    bool isActive = node.TryGetTarget(out ClientNode cn);
                    if (isActive)
                    {
                        if (cn != null)
                        {
                            if (!cn.IsConnected)
                            {
                                ToRemove.Add(node);
                            }
                        }
                        else
                        {
                            ToRemove.Add(node);
                        }
                    }
                    else
                    {
                        ToRemove.Add(node);
                    }
                }

                foreach (WeakReference<ClientNode> node in ToRemove)
                {
                    Clients.Remove(node);
                }
            }
        }
    }
}
