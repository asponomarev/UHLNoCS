using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UHLNoCS.Topologies;

namespace UHLNoCS.Models
{
    public class UOCNS : Model
    {
        public static string DefaultFifoSize = "4";
        public static string DefaultFifoCount = "4";

        public static string DefaultFlitSize = "32";
        public static string DefaultPacketSizeAvg = "10";
        public static string DefaultPacketSizeIsFixed = "true";
        public static string DefaultPacketPeriodAvg = "5";

        public static string DefaultCountRun = "1";
        public static string DefaultCountPacketRx = "1100";
        public static string DefaultCountPacketRxWarmUp = "100";
        public static string DefaultIsModeGALS = "false";

        private string TopologyNetlist;
        private string TopologyRouting;
        private string TopologyDescription;

        private bool ConfigGenerationRequired;
        private string ConfigFilePath;

        private string Topology;
        private string[] TopologyArguments;

        private string Algorithm;
        private string[] AlgorithmArguments;

        private string FifoSize;
        private string FifoCount;

        private string FlitSize;
        private string PacketSizeAvg;
        private string PacketSizeIsFixed;
        private string PacketPeriodAvg;

        private string CountRun;
        private string CountPacketRx;
        private string CountPacketRxWarmUp;
        private string IsModeGALS;

        public UOCNS(string NewType, string NewName, string NewExecutableFilePath, string NewResultsDirectoryPath,
                     bool NewConfigGenerationRequired, string NewConfigFilePath, string NewTopology, string[] NewTopologyArguments,
                     string NewAlgorithm, string[] NewAlgorithmArguments, string NewFifoSize, string NewFifoCount,
                     string NewFlitSize, string NewPacketSizeAvg, string NewPacketSizeIsFixed, string NewPacketPeriodAvg,
                     string NewCountRun, string NewCountPacketRx, string NewCountPacketRxWarmUp, string NewIsModeGALS)
                     : base(NewType, NewName, NewExecutableFilePath, NewResultsDirectoryPath)
        {
            TopologyNetlist = "";
            TopologyRouting = "";
            TopologyDescription = "";

            Type = NewType;
            Name = NewName;
            ExecutableFilePath = NewExecutableFilePath;
            ResultsDirectoryPath = NewResultsDirectoryPath;

            ConfigGenerationRequired = NewConfigGenerationRequired;
            ConfigFilePath = NewConfigFilePath;

            Topology = NewTopology;
            TopologyArguments = new string[NewTopologyArguments.Length];
            for (int ArgNo = 0; ArgNo < NewTopologyArguments.Length; ArgNo++)
            {
                TopologyArguments[ArgNo] = NewTopologyArguments[ArgNo];
            }

            Algorithm = NewAlgorithm;
            AlgorithmArguments = new string[NewAlgorithmArguments.Length];
            for (int AlgNo = 0; AlgNo < NewAlgorithmArguments.Length; AlgNo++)
            {
                AlgorithmArguments[AlgNo] = NewAlgorithmArguments[AlgNo];
            }

            FifoSize = NewFifoSize;
            FifoCount = NewFifoCount;

            FlitSize = NewFlitSize;
            PacketSizeAvg = NewPacketSizeAvg;
            PacketSizeIsFixed = NewPacketSizeIsFixed;
            PacketPeriodAvg = NewPacketPeriodAvg;

            CountRun = NewCountRun;
            CountPacketRx = NewCountPacketRx;
            CountPacketRxWarmUp = NewCountPacketRxWarmUp;
            IsModeGALS = NewIsModeGALS;
        }

        public void SetTopologyNetlist(string NewTopologyNetlist) { TopologyNetlist = NewTopologyNetlist; }
        public string GetTopologyNetlist() { return TopologyNetlist; }

        public void SetTopologyRouting(string NewTopologyRouting) { TopologyRouting = NewTopologyRouting; }
        public string GetTopologyRouting() { return TopologyRouting; }

        public void SetTopologyDescription(string NewTopologyDescription) { TopologyDescription = NewTopologyDescription; }
        public string GetTopologyDescription() { return TopologyDescription; }

        public void SetConfigGenerationRequired(bool NewConfigGenerationRequired) { ConfigGenerationRequired = NewConfigGenerationRequired; }
        public bool GetConfigGenerationRequired() { return ConfigGenerationRequired; }

        public void SetConfigFilePath(string NewConfigFilePath) { ConfigFilePath = NewConfigFilePath; }
        public string GetConfigFilePath() { return ConfigFilePath; }

        public void SetTopology(string NewTopology) { Topology = NewTopology; }
        public string GetTopology() { return Topology; }

        public void SetTopologyArguments(string[] NewTopologyArguments)
        {
            for (int ArgNo = 0; ArgNo < NewTopologyArguments.Length; ArgNo++)
            {
                TopologyArguments[ArgNo] = NewTopologyArguments[ArgNo];
            }
        }
        public string[] GetTopologyArguments() { return TopologyArguments; }

        public void SetAlgorithm(string NewAlgorithm) { Algorithm = NewAlgorithm; }
        public string GetAlgorithm() { return Algorithm; }

        public void SetAlgorithmArguments(string[] NewAlgorithmArguments)
        {
            for (int AlgNo = 0; AlgNo < NewAlgorithmArguments.Length; AlgNo++)
            {
                AlgorithmArguments[AlgNo] = NewAlgorithmArguments[AlgNo];
            }
        }
        public string[] GetAlgorithmArguments() { return AlgorithmArguments; }

        public void SetFifoSize(string NewFifoSize) { FifoSize = NewFifoSize; }
        public string GetFifoSize() { return FifoSize; }

        public void SetFifoCount(string NewFifoCount) { FifoCount = NewFifoCount; }
        public string GetFifoCount() { return FifoCount; }

        public void SetFlitSize(string NewFlitSize) { FlitSize = NewFlitSize; }
        public string GetFlitSize() { return FlitSize; }

        public void SetPacketSizeAvg(string NewPacketSizeAvg) { PacketSizeAvg = NewPacketSizeAvg; }
        public string GetPacketSizeAvg() { return PacketSizeAvg; }

        public void SetPacketSizeIsFixed(string NewPacketSizeIsFixed) { PacketSizeIsFixed = NewPacketSizeIsFixed; }
        public string GetPacketSizeIsFixed() { return PacketSizeIsFixed; }

        public void SetPacketPeriodAvg(string NewPacketPeriodAvg) { PacketPeriodAvg = NewPacketPeriodAvg; }
        public string GetPacketPeriodAvg() { return PacketPeriodAvg; }

        public void SetCountRun(string NewCountRun) { CountRun = NewCountRun; }
        public string GetCountRun() { return CountRun; }

        public void SetCountPacketRx(string NewCountPacketRx) { CountPacketRx = NewCountPacketRx; }
        public string GetCountPacketRx() { return CountPacketRx; }

        public void SetCountPacketRxWarmUp(string NewCountPacketRxWarmUp) { CountPacketRxWarmUp = NewCountPacketRxWarmUp; }
        public string GetCountPacketRxWarmUp() { return CountPacketRxWarmUp; }

        public void SetIsModeGALS(string NewIsModeGALS) { IsModeGALS = NewIsModeGALS; }
        public string GetIsModeGALS() { return IsModeGALS; }

        public void PrepareForSimulation()
        {
            if (ConfigGenerationRequired)
            {
                PrepareForConfigGeneration();
                GenerateConfigXml();
            }
        }

        public void PrepareForConfigGeneration()
        {
            if (Topology == TopologiesTypes.Mesh)
            {
                Mesh NewMesh = new Mesh(Int32.Parse(TopologyArguments[0]), Int32.Parse(TopologyArguments[1]));
                NewMesh.CreateNetlist();
                NewMesh.CreateRouting();

                TopologyNetlist = Common.MatrixToString(NewMesh.GetNetlist());
                TopologyRouting = Common.MatrixToString(NewMesh.GetRouting());
                TopologyDescription = Topology + "-(" + TopologyArguments[0] + ", " + TopologyArguments[1] + ")";
            }
            else if (Topology == TopologiesTypes.Torus)
            {
                Torus NewTorus = new Torus(Int32.Parse(TopologyArguments[0]), Int32.Parse(TopologyArguments[1]));
                NewTorus.CreateNetlist();
                NewTorus.CreateRouting();

                TopologyNetlist = Common.MatrixToString(NewTorus.GetNetlist());
                TopologyRouting = Common.MatrixToString(NewTorus.GetRouting());
                TopologyDescription = Topology + "-(" + TopologyArguments[0] + ", " + TopologyArguments[1] + ")";
            }
            else if (Topology == TopologiesTypes.Circulant)
            {
                Circulant NewCirculant = new Circulant(Int32.Parse(TopologyArguments[0]), Int32.Parse(TopologyArguments[1]), Int32.Parse(TopologyArguments[2]));
                NewCirculant.CreateNetlist();
                NewCirculant.CreateRouting(NewCirculant.AdjacencyMatrix(NewCirculant.GetNetlist(), Int32.Parse(TopologyArguments[0])), NewCirculant.GetNetlist(), Algorithm, AlgorithmArguments);

                TopologyNetlist = Common.MatrixToString(NewCirculant.GetNetlist());
                TopologyRouting = Common.MatrixToString(NewCirculant.GetRouting());
                TopologyDescription = Topology + "-(" + TopologyArguments[0] + ", " + TopologyArguments[1] + ", " + TopologyArguments[2] + ")";
            }
            else if (Topology == TopologiesTypes.OptimalCirculant)
            {
                Circulant NewCirculant = new Circulant(Int32.Parse(TopologyArguments[0]));
                NewCirculant.CreateNetlist();
                NewCirculant.CreateRouting(NewCirculant.AdjacencyMatrix(NewCirculant.GetNetlist(), Int32.Parse(TopologyArguments[0])), NewCirculant.GetNetlist(), Algorithm, AlgorithmArguments);

                TopologyNetlist = Common.MatrixToString(NewCirculant.GetNetlist());
                TopologyRouting = Common.MatrixToString(NewCirculant.GetRouting());
                TopologyDescription = Topology + "-(" + TopologyArguments[0] + ", " + NewCirculant.S1.ToString() + ", " + NewCirculant.S2.ToString() + ")";
            }

        }

        public void GenerateConfigXml()
        {
            XNamespace Xsd = "http://www.w3.org/2001/XMLSchema";
            XNamespace Xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XDocument Doc =
                new XDocument(
                    new XDeclaration("1.0", "UTF-8", "no"),
                    new XElement("TaskOCNS",
                            new XAttribute(XNamespace.Xmlns + "xsd", Xsd),
                            new XAttribute(XNamespace.Xmlns + "xsi", Xsi),
                            new XAttribute("Description", TopologyDescription),
                        new XElement("Network",
                            new XElement("Netlist", TopologyNetlist),
                            new XElement("Routing", TopologyRouting),
                            new XElement("Link",
                                new XElement("Parameter", new XAttribute("FifoSize", FifoSize)),
                                new XElement("Parameter", new XAttribute("FifoCount", FifoCount))
                            )
                        ),
                        new XElement("Traffic",
                            new XElement("Parameter", new XAttribute("FlitSize", FlitSize)),
                            new XElement("Parameter", new XAttribute("PacketSizeAvg", PacketSizeAvg)),
                            new XElement("Parameter", new XAttribute("PacketSizeIsFixed", PacketSizeIsFixed)),
                            new XElement("Parameter", new XAttribute("PacketPeriodAvg", PacketPeriodAvg))
                        ),
                        new XElement("Simulation",
                            new XElement("Parameter", new XAttribute("CountRun", CountRun)),
                            new XElement("Parameter", new XAttribute("CountPacketRx", CountPacketRx)),
                            new XElement("Parameter", new XAttribute("CountPacketRxWarmUp", CountPacketRxWarmUp)),
                            new XElement("Parameter", new XAttribute("IsModeGALS", IsModeGALS))
                        )
                    )
                );
            Doc.Save(ConfigFilePath);
        }
    }
}
