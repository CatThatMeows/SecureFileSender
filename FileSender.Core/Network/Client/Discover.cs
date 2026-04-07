using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace FileSender.Core.Network.Client
{
    public class Discover
    {
        public async Task<bool> ConnectDummmy() //Basically port scan, cry about it
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus != OperationalStatus.Up)
                    continue;
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                IPInterfaceProperties ipProps = ni.GetIPProperties();

                foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                {
                    
                    if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        byte[] ip = addr.Address.GetAddressBytes();
                        //Just try the /24, if you use something else thats sad, u can still direct connect.
                        for(byte i = 0; i < 255; i++)
                        {
                            ip[3] = i;
                            SemaphoreSlim semaphore = new SemaphoreSlim(50);

                        }
                    }
                }
            }

            return false;
        }
    }
}
