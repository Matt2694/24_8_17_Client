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
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            TcpClient client = new TcpClient("localhost", 5000);
            StreamReader sr = new StreamReader(client.GetStream());
            StreamWriter sw = new StreamWriter(client.GetStream());

            try
            {
                string data = Console.ReadLine();
                sw.WriteLine(data);
                sw.Flush();
                while (data != null && data != "")
                {
                    data = sr.ReadLine();
                    Console.WriteLine(data);

                    data = Console.ReadLine();
                    sw.WriteLine(data);
                    sw.Flush();
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
