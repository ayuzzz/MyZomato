using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class ServicebusConnectionObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string VhostName { get; set; }
        public string Hostname { get; set; }
    }
}
