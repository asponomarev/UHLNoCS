using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UHLNoCS
{
    class Common
    {
        public static string TopologyMesh = "Mesh";
        public static string TopologyTorus = "Torus";
        public static string TopologyCirculant = "Circulant";
        public static string TopologyOptimalCirculant = "CirculantOpt";

        public static string AlgorithmDijkstra = "Dijkstra";
        public static string AlgorithmPO = "PO";
        public static string AlgorithmROU = "ROU";

        public static void CreateXml(string Filename, string Description, string Netlist, string Routing)
        {
            XNamespace Xsd = "http://www.w3.org/2001/XMLSchema";
            XNamespace Xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XDocument Doc =
                new XDocument(
                    new XDeclaration("1.0", "UTF-8", "no"),
                    new XElement("TaskOCNS",
                            new XAttribute(XNamespace.Xmlns + "xsd", Xsd),
                            new XAttribute(XNamespace.Xmlns + "xsi", Xsi),
                            new XAttribute("Description", Description),
                        new XElement("Network",
                            new XElement("Netlist", Netlist),
                            new XElement("Routing", Routing),
                            new XElement("Link",
                                new XElement("Parameter", new XAttribute("FifoSize", "4")),
                                new XElement("Parameter", new XAttribute("FifoCount", "4"))
                            )
                        ),
                        new XElement("Traffic",
                            new XElement("Parameter", new XAttribute("FlitSize", "32")),
                            new XElement("Parameter", new XAttribute("PacketSizeAvg", "10")),
                            new XElement("Parameter", new XAttribute("PacketSizeIsFixed", "true")),
                            new XElement("Parameter", new XAttribute("PacketPeriodAvg", "5"))
                        ),
                        new XElement("Simulation",
                            new XElement("Parameter", new XAttribute("CountRun", "1")),
                            new XElement("Parameter", new XAttribute("CountPacketRx", "1100")),
                            new XElement("Parameter", new XAttribute("CountPacketRxWarmUp", "100")),
                            new XElement("Parameter", new XAttribute("IsModeGALS", "false"))
                        )
                    )
                );
            Doc.Save(Filename);
        }
    }

}
