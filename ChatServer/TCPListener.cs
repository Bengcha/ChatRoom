using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
   class TCPListener
    {
        TCPServer newTCPServer = new TCPServer();
        public void Start()
        {
            newTCPServer.ConnectUser();
            newTCPServer.LookForUserIPAddress();
        }
    }
}

