using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS
{
    // class represents abstract NoC topology
    public abstract class Network
    {
        public static int PortNumber = 4;  // amount of router ports

        protected int[,] Netlist;  // Connections table for NoC
        protected int[,] Routing;  // Routing table for NoC
    }
}
