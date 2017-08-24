using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _24_8_17_Client
{
    class Program
    {
        private static TcpClient client = null;
        private static StreamReader reader = null;
        private static StreamWriter writer = null;
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            client = new TcpClient("localhost", 5000);
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;

            try
            {
                string data = Console.ReadLine();
                writer.WriteLine(data);
                while (data != null && data != "")
                {
                    data = reader.ReadLine();
                    Console.WriteLine(data);

                    data = Console.ReadLine();
                    writer.WriteLine(data);
                }
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
