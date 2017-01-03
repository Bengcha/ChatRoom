using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;



namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPClient user = new TCPClient();
            user.ConnectClient();
            user.UserMessages();
        }
    }
}
