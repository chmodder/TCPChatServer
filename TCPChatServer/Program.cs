using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPChatServer
{
    class TcpServer
    {
        static void Main(string[] args)
        {

            #region my 2 way server code
            //set up server
            TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();
            Console.WriteLine($"Server started");
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine($"Server activated");

            Stream ns = connectionSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);

            while (true)
            {
                //receive message  
                string receivedMsg = sr.ReadLine();
                Console.WriteLine($"Client: {receivedMsg}");
                //send message
                string sendMsg = Console.ReadLine();
                sw.WriteLine(sendMsg);
                sw.AutoFlush = true;
            }
            #endregion


        }
    }
}
