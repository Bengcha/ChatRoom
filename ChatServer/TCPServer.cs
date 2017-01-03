using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace ChatServer
{
    public class TCPServer
    {
        Dictionary<string, EndPoint> SaveUsers;
        Queue<string> messages;
        EndPoint UsersIPAdress;
        Int32 port;
        IPAddress userIPAddress;
        TcpListener connecting;
        public TCPServer()
        {
            connecting = null;
            userIPAddress = IPAddress.Any;
            port = 4444;
            messages = new Queue<string>();
            SaveUsers = new Dictionary<string, EndPoint>();        
        }
        public void ConnectUser()
        {
            try
            {
                connecting = new TcpListener(userIPAddress, port);
                connecting.Start();
                Console.WriteLine("Waiting for a Connection.");
                Byte[] bytes = new Byte[256];
                string name = null;
                string userMessage = null;

                while (true)
                {
                    TcpClient client = connecting.AcceptTcpClient();
                    Console.WriteLine("You are now connected.");

                    name = null;
                    userMessage = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        name = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        userMessage = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        name = name.ToUpper();
                        byte[] nameEntered = System.Text.Encoding.ASCII.GetBytes(name);
                        stream.Write(nameEntered, 0, nameEntered.Length);
                        byte[] messages = System.Text.Encoding.ASCII.GetBytes(userMessage);
                        Console.WriteLine("Received Message: {0}", name);
                        Console.WriteLine("Send Message: {0}", userMessage);
                        stream.Flush();
                    }
                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Socket Exception: {0}", e);
            }
            finally
            {
                if (connecting != null)
                    connecting.Stop();
            }
        }
        public void ListeningForMessages()
        {
            try
            {
                connecting = new TcpListener(userIPAddress, port);
                connecting.Start();
                Byte[] bytes = new Byte[256];
                string message = null;

                while (true)
                {
                    TcpClient client = connecting.AcceptTcpClient();
                    Console.WriteLine("Message accepted");
                    message = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        message = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received Messages: {0}", message);

                        byte[] msg = Encoding.ASCII.GetBytes(message);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Messages Send: {0}", message);
                        stream.Flush();
                    }
                    stream.Close();
                    client.Close();

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Socket Exception: {0}", e);
            }
            finally
            {
                if (connecting != null)
                    connecting.Stop();
            }
        }

        public EndPoint LookForUserIPAddress()
        {
            IPEndPoint userIPA = new IPEndPoint(userIPAddress, port);
            return this.UsersIPAdress;

        }

    }
}

    




