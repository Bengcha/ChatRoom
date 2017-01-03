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
    class Users
    {
            
        public TcpClient userName;
        public IPAddress userIPAddress
        { get;
          set;
        }
        public Users(TcpClient userName)
        {
            this.userName = userName;
        }
    }
}

