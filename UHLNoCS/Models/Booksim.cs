using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Models
{
    public class Booksim : Model
    {
        public static string DefaultConfigFileName = "config";
        public static string DefaultResultFileName = "result.txt";

        public static string BeforeSectionHeader = "Time taken is";
        public static string SectionHeader = "Overall Traffic Statistics";

        public static string[] Topologies = new string[] { "fly", "mesh", "single", "torus", "cmesh", "flatfly", "fattree", "quadtree" };
        public static int DefaultTopologyIndex = 1;
        public static string DefaultTopologyArguments = "2 2";
        public static string[] RoutingFunctions = new string[] { "dim_order", "dor", "dor_no_express", "min", "ran_min" };
        public static int DefaultRoutingFunction = 0;
        public static string DefaulVirtualChannelsAmount = "4";
        public static string DefaultVirtualChannelsBufferSize = "4";
        public static string[] TrafficTypes = new string[] { "uniform", "bitcomp", "bitrev", "shuffle", "transpose", "tornado", "neighbor" };
        public static int DefaultTrafficType = 0;
        public static string DefaultPacketSize = "10";
        public static string DefaultSimulationPeriodLength = "1000";
        public static string DefaultWarmUpPeriodsAmount = "1";
        public static string DefaultMaxPeriodsAmount = "5";
        public static string DefaultInjectionRate = "0.1";
        public static string[] SimulationTypes = new string[] { "latency", "throughput" };
        public static int DefaultSimulationType = 0;

        private bool ConfigGenerationRequired;
        private string ConfigFilePath;

        private string Topology;
        private string[] TopologyArguments;

        private string RoutingFunction;

        private string VirtualChannelsAmount;
        private string VirtualChannelsBufferSize;

        private string TrafficType;
        private string PacketSize;

        private string SimulationPeriodLength;
        private string WarmUpPeriodsAmount;
        private string MaxPeriodsAmount;
        private string SimulationType;
        private string InjectionRate;

        public Booksim(string NewType, string NewName, string NewExecutableFilePath, string NewResultsDirectoryPath,
                       bool NewConfigGenerationRequired, string NewConfigFilePath, string NewTopology, string[] NewTopologyArguments,
                       string NewRoutingFunction, string NewVirtualChannelsAmount, string NewVirtualChannelsBufferSize,
                       string NewTrafficType, string NewPacketSize, string NewSimulationPeriodLength, string NewWarmUpPeriodsAmount,
                       string NewMaxPeriodsAmount, string NewSimulationType, string NewInjectionRate)
                      : base(NewType, NewName, NewExecutableFilePath, NewResultsDirectoryPath)
        {
            Type = NewType;
            Name = NewName;
            ExecutableFilePath = NewExecutableFilePath;
            ResultsDirectoryPath = NewResultsDirectoryPath;

            ConfigGenerationRequired = NewConfigGenerationRequired;
            ConfigFilePath = NewConfigFilePath;

            Topology = NewTopology;
            TopologyArguments = new string[] { "", "", "", "", "", "", "" }; // k, n, c, x, y, xr, yr
            for (int ArgNo = 0; ArgNo < NewTopologyArguments.Length; ArgNo++)
            {
                TopologyArguments[ArgNo] = NewTopologyArguments[ArgNo];
            }

            RoutingFunction = NewRoutingFunction;

            VirtualChannelsAmount = NewVirtualChannelsAmount;
            VirtualChannelsBufferSize = NewVirtualChannelsBufferSize;

            TrafficType = NewTrafficType;
            PacketSize = NewPacketSize;

            SimulationPeriodLength = NewSimulationPeriodLength;
            WarmUpPeriodsAmount = NewWarmUpPeriodsAmount;
            MaxPeriodsAmount = NewMaxPeriodsAmount;
            SimulationType = NewSimulationType;
            InjectionRate = NewInjectionRate;
        }

        public void SetConfigGenerationRequired (bool NewConfigGenerationRequired) { ConfigGenerationRequired = NewConfigGenerationRequired; }
        public bool GetConfigGenerationRequired() { return ConfigGenerationRequired; }

        public void SetConfigFilePath(string NewConfigFilePath) { ConfigFilePath = NewConfigFilePath; }
        public string GetConfigFilePath() { return ConfigFilePath; }

        public void SetTopology(string NewTopology) { Topology = NewTopology; }
        public string GetTopology() { return Topology; }

        public void SetTopologyArguments(string[] NewTopologyArguments)
        {
            TopologyArguments = new string[] { "", "", "", "", "", "", "" }; // k, n, c, x, y, xr, yr
            for (int ArgNo = 0; ArgNo < NewTopologyArguments.Length; ArgNo++)
            {
                TopologyArguments[ArgNo] = NewTopologyArguments[ArgNo];
            }
        }
        public string[] GetTopologyArguments() { return TopologyArguments; }

        public void SetRoutingFunction(string NewRoutingFunction) { RoutingFunction = NewRoutingFunction; }
        public string GetRoutingFunction() { return RoutingFunction; }

        public void SetVirtualChannelsAmount(string NewVirtualChannelsAmount) { VirtualChannelsAmount = NewVirtualChannelsAmount; }
        public string GetVirtualChannelsAmount() { return VirtualChannelsAmount; }

        public void SetVirtualChannelsBufferSize(string NewVirtualChannelsBufferSize) { VirtualChannelsBufferSize = NewVirtualChannelsBufferSize; }
        public string GetVirtualChannelsBufferSize() { return VirtualChannelsBufferSize; }

        public void SetTrafficType(string NewTrafficType) { TrafficType = NewTrafficType; }
        public string GetTrafficType() { return TrafficType; }

        public void SetPacketSize(string NewPacketSize) { PacketSize = NewPacketSize; }
        public string GetPacketSize() { return PacketSize; }

        public void SetSimulationPeriodLength(string NewSimulationPeriodLength) { SimulationPeriodLength = NewSimulationPeriodLength; }
        public string GetSimulationPeriodLength() { return SimulationPeriodLength; }

        public void SetWarmUpPeriodsAmount(string NewWarmUpPeriodsAmount) { WarmUpPeriodsAmount = NewWarmUpPeriodsAmount; }
        public string GetWarmUpPeriodsAmount() { return WarmUpPeriodsAmount; }

        public void SetMaxPeriodsAmount(string NewMaxPeriodsAmount) { MaxPeriodsAmount = NewMaxPeriodsAmount; }
        public string GetMaxPeriodsAmount() { return MaxPeriodsAmount; }

        public void SetSimulationType(string NewSimulationType) { SimulationType = NewSimulationType; }
        public string GetSimulationType() { return SimulationType; }

        public void SetInjectionRate(string NewInjectionRate) { InjectionRate = NewInjectionRate; }
        public string GetInjectionRate() { return InjectionRate; }

        public void PrepareForSimulation()
        {
            if (ConfigGenerationRequired)
            {
                GenerateConfigFile();
            }
        }

        public void GenerateConfigFile()
        {
            string ConfigInfo = "// Topology\r\n";
            ConfigInfo += "topology = " + Topology + ";\r\n";
            string[] Args = new string[] { "k", "n", "c", "x", "y", "xr", "yr" };
            for (int ArgNo = 0; ArgNo < Args.Length; ArgNo++)
            {
                if (TopologyArguments[ArgNo] != "")
                {
                    ConfigInfo += Args[ArgNo] + " = " + TopologyArguments[ArgNo] + ";\r\n";
                }
            }

            ConfigInfo += "\r\n// Routing\r\n";
            ConfigInfo += "routing_function = " + RoutingFunction + ";\r\n";

            ConfigInfo += "\r\n// Flow control\r\n";
            ConfigInfo += "num_vcs = " + VirtualChannelsAmount + ";\r\n";
            ConfigInfo += "vc_buf_size = " + VirtualChannelsBufferSize + ";\r\n";

            ConfigInfo += "\r\n// Traffic\r\n";
            ConfigInfo += "traffic = " + TrafficType + ";\r\n";
            ConfigInfo += "packet_size = " + PacketSize + ";\r\n";

            ConfigInfo += "\r\n// Simulation\r\n";
            ConfigInfo += "sim_type = " + SimulationType + ";\r\n";
            ConfigInfo += "injection_rate = " + InjectionRate + ";\r\n";
            ConfigInfo += "sample_period = " + SimulationPeriodLength + ";\r\n";
            ConfigInfo += "warmup_periods = " + WarmUpPeriodsAmount + ";\r\n";
            ConfigInfo += "max_samples = " + MaxPeriodsAmount + ";\r\n";

            Random SeedGenerator = new Random();
            ConfigInfo += "seed = " + SeedGenerator.Next(0, 1000000).ToString() + ";\r\n";

            File.WriteAllText(ConfigFilePath, ConfigInfo);
        }

        public string[,] CollectSimulationResults()
        {
            int CharacteristicsAmount = 11;

            int PacketLatencyAverageLine = 2;
            int PacketLatencyAveraveIndex = 0;

            int NetworkLatencyAverageLine = 5;
            int NetworkLatencyAverageIndex = 1;

            int FlitLatencyAverageLine = 8;
            int FlitLatencyAverageIndex = 2;

            int FragmentationAverageLine = 11;
            int FragmentationAverageIndex = 3;

            int InjectedPacketRateAverageLine = 14;
            int InjectedPacketRateAverageIndex = 4;

            int AcceptedPacketRateAverageLine = 17;
            int AcceptedPacketRateAverageIndex = 5;

            int InjectedFlitRateAverageLine = 20;
            int InjectedFlitRateAverageIndex = 6;

            int AcceptedFlitRateAverageLine = 23;
            int AcceptedFlitRateAverageIndex = 7;

            int InjectedPacketSizeAverageLine = 26;
            int InjectedPacketSizeAverageIndex = 8;

            int AcceptedPacketSizeAverageLine = 27;
            int AcceptedPacketSizeAverageIndex = 9;

            int HopsAverageLine = 28;
            int HopsAverageIndex = 10;

            int SectionsAmount = 0;

            string[] ResultSections = File.ReadAllLines(ResultsDirectoryPath + "\\" + DefaultResultFileName);
            foreach (string ResultString in ResultSections)
            {
                if (ResultString.Contains(SectionHeader))
                {
                    SectionsAmount++;
                }
            }
            string[,] Result = new string[SectionsAmount, CharacteristicsAmount];

            int SectionIndex = -1;
            int SectionLineIndex = 0;
            bool InSection = false;
            foreach (string ResultString in ResultSections)
            {
                if (ResultString.Contains(SectionHeader))
                {
                    SectionIndex++;
                    SectionLineIndex = 0;
                    InSection = true;
                }
                else if (SectionLineIndex == PacketLatencyAverageLine && InSection)
                {
                    Result[SectionIndex, PacketLatencyAveraveIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == NetworkLatencyAverageLine && InSection)
                {
                    Result[SectionIndex, NetworkLatencyAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == FlitLatencyAverageLine && InSection)
                {
                    Result[SectionIndex, FlitLatencyAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == FragmentationAverageLine && InSection)
                {
                    Result[SectionIndex, FragmentationAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == InjectedPacketRateAverageLine && InSection)
                {
                    Result[SectionIndex, InjectedPacketRateAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == AcceptedPacketRateAverageLine && InSection)
                {
                    Result[SectionIndex, AcceptedPacketRateAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == InjectedFlitRateAverageLine && InSection)
                {
                    Result[SectionIndex, InjectedFlitRateAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == AcceptedFlitRateAverageLine && InSection)
                {
                    Result[SectionIndex, AcceptedFlitRateAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == InjectedPacketSizeAverageLine && InSection)
                {
                    Result[SectionIndex, InjectedPacketSizeAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == AcceptedPacketSizeAverageLine && InSection)
                {
                    Result[SectionIndex, AcceptedPacketSizeAverageIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == HopsAverageLine && InSection)
                {
                    Result[SectionIndex, HopsAverageIndex] = ExtractValue(ResultString);
                    InSection = false;
                }

                SectionLineIndex++;
            }

            return Result;
        }

        public string ExtractValue(string TxtString)
        {
            int IndexBefore = TxtString.IndexOf('=') + 1;
            int IndexAfter = TxtString.IndexOf('(') - 1;
            string Value = TxtString.Substring(IndexBefore + 1, IndexAfter - IndexBefore - 1);

            return Value;
        }

    }
}
