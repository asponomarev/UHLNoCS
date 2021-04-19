using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UHLNoCS.Topologies;

namespace UHLNoCS.Models
{
    public class UOCNS : Model
    {
        public static string DefaultConfigFileName = "config.xml";
        public static string DefaultResultFileName = "result.html";

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

        public string[,] CollectSimulationResults()
        {
            string ResultsSectionHeader = "Конфигурация сети на кристалле:";

            int PacketsGenerationPeriodAvgLine = 40;
            int PacketsGenerationPeriodAvgIndex = 0;

            int ModellingTimeLine = 83;
            int ModellingTimeIndex = 1;

            int PacketsSentLine = 91;
            int PacketsSentIndex = 2;

            int PacketsReceivedLine = 97;
            int PacketsReceivedIndex = 3;

            int PacketGenerationErrorsLine = 103;
            int PacketGenerationErrorsIndex = 4;

            int PacketGenerationSpeedLine = 111;
            int PacketGenerationSpeedIndex = 5;

            int FlitsGenerationSpeedLine = 117;
            int FlitsGenerationSpeedIndex = 6;

            int FlitsSendingSpeedLine = 123;
            int FlitsSendingSpeedIndex = 7;

            int PacketsDeliveryTimeLine = 129;
            int PacketsDeliveryTimeIndex = 8;

            int PacketsHopsLine = 135;
            int PacketsHopsIndex = 9;

            int NetworkThroughoutLine = 143;
            int NetworkThroughoutIndex = 10;

            int RouterThroughoutLine = 149;
            int RouterThroughoutIndex = 11;

            int CoreReceivingBuffersLoadLine = 157;
            int CoreReceivingBuffersLoadIndex = 12;

            int CoreSendingBuffersLoadLine = 163;
            int CoreSendingBuffersLoadIndex = 13;

            int RouterReceivingBuffersLoadLine = 171;
            int RouterReceivingBuffersLoadIndex = 14;

            int RouterSendingBuffersLoadLine = 177;
            int RouterSendingBuffersLoadIndex = 15;

            int BuffersLoadLine = 185;
            int BuffersLoadIndex = 16;

            int PhysicChannelsLoadLine = 191;
            int PhysicChannelsLoadIndex = 17;

            int CharacteristicsAmount = 18;


            int SectionsAmount = 0;
            string[] ResultSections = File.ReadAllLines(ResultsDirectoryPath + "\\" + DefaultResultFileName);
            foreach (string ResultString in ResultSections)
            {
                if (ResultString.Contains(ResultsSectionHeader))
                {
                    SectionsAmount++;
                }
            }
            string[,] Result = new string[SectionsAmount, CharacteristicsAmount];

            int SectionIndex = -1;
            int SectionLineIndex = 0;
            foreach (string ResultString in ResultSections)
            {
                if (ResultString.Contains(ResultsSectionHeader))
                {
                    SectionIndex++;
                    SectionLineIndex = 0;
                }
                else if (SectionLineIndex == PacketsGenerationPeriodAvgLine)
                {
                    Result[SectionIndex, PacketsGenerationPeriodAvgIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == ModellingTimeLine)
                {
                    Result[SectionIndex, ModellingTimeIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PacketsSentLine)
                {
                    Result[SectionIndex, PacketsSentIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PacketsReceivedLine)
                {
                    Result[SectionIndex, PacketsReceivedIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PacketGenerationErrorsLine)
                {
                    Result[SectionIndex, PacketGenerationErrorsIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PacketGenerationSpeedLine)
                {
                    Result[SectionIndex, PacketGenerationSpeedIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == FlitsGenerationSpeedLine)
                {
                    Result[SectionIndex, FlitsGenerationSpeedIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == FlitsSendingSpeedLine)
                {
                    Result[SectionIndex, FlitsSendingSpeedIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PacketsDeliveryTimeLine)
                {
                    Result[SectionIndex, PacketsDeliveryTimeIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PacketsHopsLine)
                {
                    Result[SectionIndex, PacketsHopsIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == NetworkThroughoutLine)
                {
                    Result[SectionIndex, NetworkThroughoutIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == RouterThroughoutLine)
                {
                    Result[SectionIndex, RouterThroughoutIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == CoreReceivingBuffersLoadLine)
                {
                    Result[SectionIndex, CoreReceivingBuffersLoadIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == CoreSendingBuffersLoadLine)
                {
                    Result[SectionIndex, CoreSendingBuffersLoadIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == RouterReceivingBuffersLoadLine)
                {
                    Result[SectionIndex, RouterReceivingBuffersLoadIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == RouterSendingBuffersLoadLine)
                {
                    Result[SectionIndex, RouterSendingBuffersLoadIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == BuffersLoadLine)
                {
                    Result[SectionIndex, BuffersLoadIndex] = Common.ExtractValue(ResultString);
                }
                else if (SectionLineIndex == PhysicChannelsLoadLine)
                {
                    Result[SectionIndex, PhysicChannelsLoadIndex] = Common.ExtractValue(ResultString);
                }

                SectionLineIndex++;
            }

            return Result;
        }

    }
}
