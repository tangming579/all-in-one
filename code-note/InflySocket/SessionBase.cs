using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace InflySocket
{
    public class SessionBase
    {
        public string EndPoint { get; set; }

        public Socket TcpSocket { get; internal set; }
    }
}
