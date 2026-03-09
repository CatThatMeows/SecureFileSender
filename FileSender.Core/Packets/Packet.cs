using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSender.Core.Packets
{
    public class Packet
    {
        public string Value { get; set; }
        public string PacketType { get; set; }
        [JsonIgnore]
        public int Size { get; set; }

        public byte[] Serialize()
        {
            string serObj = JsonConvert.SerializeObject(this);
            Size = UTF8Encoding.UTF8.GetByteCount(serObj);
            return UTF8Encoding.UTF8.GetBytes(serObj);
        }       
        public static Packet DeSerialize(byte[] input)
        {
            string PacketString = UTF8Encoding.UTF8.GetString(input);
            return JsonConvert.DeserializeObject<Packet>(PacketString);
        }
        public T GetValue<T>()
        {
            return JsonConvert.DeserializeObject<T>(Value);
        }
    }
}
