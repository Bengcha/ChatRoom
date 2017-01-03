using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace ClientServer
{
    public class TCPClient
    {
        Int32 socket = 4444;
        string server = "127.0.0.1";

        public void ConnectClient()
        {
            try
            {
                TcpClient client = new TcpClient(server, socket);
                Console.WriteLine("Enter a username...");
                string userName = Console.ReadLine();
                Byte[] Clientname = System.Text.Encoding.ASCII.GetBytes(userName);
                NetworkStream stream = client.GetStream();
                stream.Write(Clientname, 0, Clientname.Length);
                Clientname = new Byte[256];
                string data = string.Empty;
                Int32 bytes = stream.Read(Clientname, 0, Clientname.Length); 
                data = System.Text.Encoding.ASCII.GetString(Clientname, 0, bytes);
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArguementNullException: {0}", e);

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);

            }
            Console.WriteLine("You are now connected. You can start sending messages.");
            Console.Read();

        }

        public void UserMessages()
        {
            try
            {
                TcpClient client = new TcpClient(server, socket);
                Console.WriteLine("");
                string userMessage = Console.ReadLine();
                Byte[] messages = System.Text.Encoding.ASCII.GetBytes(userMessage);
                NetworkStream stream = client.GetStream();
                stream.Write(messages, 0, messages.Length);
                messages = new Byte[256];
                string data = string.Empty;
                Int32 bytes = stream.Read(messages, 0, messages.Length);
                data = System.Text.Encoding.ASCII.GetString(messages, 0, bytes);
                stream.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArguementNullException: {0}", e);

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);

            }
        }
    }
}

