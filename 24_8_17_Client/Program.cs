using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _24_8_17_Client
{
    class Program
    {
        //private static TcpClient client = null;
        //private static StreamReader reader = null;
        //private static StreamWriter writer = null;

        static void Main(string[] args)
        {
            Program client = new Program();
            client.Run();
        }

        private void Run()
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(new IPEndPoint(IPAddress.Loopback, 5000));
                while (true)
                {
                    string command = Console.ReadLine();
                    byte[] msg = Encoding.ASCII.GetBytes(command);
                    s.Send(msg);
                    byte[] retMsg = new byte[1024];
                    s.Receive(retMsg);
                    string str = Encoding.ASCII.GetString(retMsg);
                    int i = str.IndexOf('\0');
                    str = str.Substring(0, i);
                    Console.WriteLine(str);
                    
                }
                //Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

            //client = new TcpClient("localhost", 5000);
            //reader = new StreamReader(client.GetStream());
            //writer = new StreamWriter(client.GetStream());
            //writer.AutoFlush = true;

            //try
            //{
            //    string data = Console.ReadLine();
            //    writer.WriteLine(data);
            //    while (data != null && data != "")
            //    {
            //        data = reader.ReadLine();
            //        Console.WriteLine(data);

            //        data = Console.ReadLine();
            //        writer.WriteLine(data);
            //    }
            //    client.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
