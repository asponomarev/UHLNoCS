using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Models
{
    public class Newxim : Model
    {
        public static string DefaultConfigFileName = "config.yml";
        public static string DefaultResultFileName = "result.txt";

        public static string ResultSectionHeader = "Noxim simulation completed";

        public static string[] Topologies = new string[] { "MESH", "TORUS", "CIRCULANT", "TREE" };
        public static int DefaultTopology = 0;
        public static string DefaultTopologyArguments = "2 2";
        public static string[] RoutingAlgorithms = new string[] {"DIJKSTRA", "UP_DOWN", "MESH_XY", "CIRCULANT_PAIR_EXCHANGE", "GREEDY_PROMOTION",
                                                                 "CIRCULANT_MULTIPLICATIVE", "CIRCULANT_CLOCKWISE", "CIRCULANT_ADAPTIVE" };
        public static int DefaultRoutingAlgorithm = 0;
        public static string DefaultTopologyChannels = "1";
        public static string DefaultVirtualChannels = "1";
        public static string DefaultBufferDepth = "2";
        public static string DefaultMinPacketSize = "10";
        public static string DefaultMaxPacketSize = "10";
        public static string DefaultPacketInjectionRate = "0.05";
        public static string DefaultSimulationTime = "100000";
        public static string DefaultWarmUpTime = "0";
        public static string DefaultIterationsAmount = "20";

        private bool ConfigGenerationRequired;
        private string ConfigFilePath;

        private string Topology;
        private string[] TopologyArguments;
        private string RoutingAlgorithm;

        private string TopologyChannels;
        private string VirtualChannels;
        private string BufferDepth;

        private string MinPacketSize;
        private string MaxPacketSize;
        private string PacketInjectionRate;
    
        private string SimulationTime;
        private string WarmUpTime;
        private string IterationsAmount;

        public Newxim(string NewType, string NewName, string NewExecutableFilePath, string NewResultsDirectoryPath,
                      bool NewConfigGenerationRequired, string NewConfigFilePath, string NewTopology, string[] NewTopologyArguments,
                      string NewRoutingAlgorithm, string NewTopologyChannels, string NewVirtualChannels, string NewBufferDepth,
                      string NewMinPacketSize, string NewMaxPacketSize, string NewPacketInjectionRate,
                      string NewSimulationTime, string NewWarmUpTime, string NewIterationsAmount)
                      : base(NewType, NewName, NewExecutableFilePath, NewResultsDirectoryPath)
        {
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
            RoutingAlgorithm = NewRoutingAlgorithm;

            TopologyChannels = NewTopologyChannels;
            VirtualChannels = NewVirtualChannels;
            BufferDepth = NewBufferDepth;

            MinPacketSize = NewMinPacketSize;
            MaxPacketSize = NewMaxPacketSize;
            PacketInjectionRate = NewPacketInjectionRate;

            SimulationTime = NewSimulationTime;
            WarmUpTime = NewWarmUpTime;
            IterationsAmount = NewIterationsAmount;
        }

        public void SetConfigGenerationRequired(bool NewConfigGenerationRequired) { ConfigGenerationRequired = NewConfigGenerationRequired; }
        public bool GetConfigGenerationRequired() { return ConfigGenerationRequired; }

        public void SetConfigFilePath(string NewConfigFilePath) { ConfigFilePath = NewConfigFilePath; }
        public string GetConfigFilePath() { return ConfigFilePath; }

        public void SetTopology(string NewTopology) { Topology = NewTopology; }
        public string GetTopology() { return Topology; }

        public void SetTopologyArguments(string[] NewTopologyArguments)
        {
            TopologyArguments = new string[NewTopologyArguments.Length];
            for (int ArgNo = 0; ArgNo < NewTopologyArguments.Length; ArgNo++)
            {
                TopologyArguments[ArgNo] = NewTopologyArguments[ArgNo];
            }
        }
        public string[] GetTopologyArguments() { return TopologyArguments; }

        public void SetRoutingAlgorithm(string NewRoutingAlgorithm) { RoutingAlgorithm = NewRoutingAlgorithm; }
        public string GetRoutingAlgorithm() { return RoutingAlgorithm; }

        public void SetTopologyChannels(string NewTopologyChannels) { TopologyChannels = NewTopologyChannels; }
        public string GetTopologyChannels() { return TopologyChannels; }

        public void SetVirtualChannels(string NewVirtualChannels) { VirtualChannels = NewVirtualChannels; }
        public string GetVirtualChannels() { return VirtualChannels; }

        public void SetBufferDepth(string NewBufferDepth) { BufferDepth = NewBufferDepth; }
        public string GetBufferDepth() { return BufferDepth; }

        public void SetMinPacketSize(string NewMinPacketSize) { MinPacketSize = NewMinPacketSize; }
        public string GetMinPacketSize() { return MinPacketSize; }

        public void SetMaxPacketSize(string NewMaxPacketSize) { MaxPacketSize = NewMaxPacketSize; }
        public string GetMaxPacketSize() { return MaxPacketSize; }

        public void SetPacketInjectionRate(string NewPacketInjectionRate) { PacketInjectionRate = NewPacketInjectionRate; }
        public string GetPacketInjectionRate() { return PacketInjectionRate; }

        public void SetSimulationTime(string NewSimulationTime) { SimulationTime = NewSimulationTime; }
        public string GetSimulationTime() { return SimulationTime; }

        public void SetWarmUpTime(string NewWarmUpTime) { WarmUpTime = NewWarmUpTime; }
        public string GetWarmUpTime() { return WarmUpTime; }

        public void SetIterationsAmount(string NewIterationsAmount) { IterationsAmount = NewIterationsAmount; }
        public string GetIterationsAmount() { return IterationsAmount; }

        public void PrepareForSimulation()
        {
            if (ConfigGenerationRequired)
            {
                GenerateConfigFile();
            }
        }

        public void GenerateConfigFile()
        {
            string ConfigInfo = "";
            ConfigInfo += "topology: " + Topology + "\r\n";

            ConfigInfo += "topology_args: [";
            for (int ArgNo = 0; ArgNo < TopologyArguments.Length; ArgNo++)
            {
                ConfigInfo += TopologyArguments[ArgNo];
                if (ArgNo != TopologyArguments.Length - 1)
                {
                    ConfigInfo += ", ";
                }
            }
            ConfigInfo += "]\r\n";

            ConfigInfo += "topology_channels: " + TopologyChannels + "\r\n";
            ConfigInfo += "virtual_channels: " + VirtualChannels + "\r\n";
            ConfigInfo += "subtopology: TGEN_0\r\n";
            ConfigInfo += "subnetwork: PHYSICAL\r\n";
            ConfigInfo += "update_sequence: DEFAULT\r\n";
            ConfigInfo += "buffer_depth: " + BufferDepth + "\r\n";
            ConfigInfo += "min_packet_size: " + MinPacketSize + "\r\n";
            ConfigInfo += "max_packet_size: " + MaxPacketSize + "\r\n";
            ConfigInfo += "flit_injection_rate: true\r\n";
            ConfigInfo += "scale_with_nodes: false\r\n";
            ConfigInfo += "packet_injection_rate: " + PacketInjectionRate + "\r\n";
            ConfigInfo += "probability_of_retransmission: 1\r\n";
            ConfigInfo += "routing_algorithm: SUBNETWORK\r\n";
            ConfigInfo += "selection_strategy: RANDOM\r\n";
            ConfigInfo += "routing_table: " + RoutingAlgorithm + "\r\n";
            ConfigInfo += "routing_table_id_based: true\r\n";

            Random SeedGenerator = new Random();
            ConfigInfo += "rnd_generator_seed: " + SeedGenerator.Next(0, 1000000).ToString() + "\r\n";

            ConfigInfo += "report_progress: false\r\n";
            ConfigInfo += "report_buffers: false\r\n";
            ConfigInfo += "report_topology_graph: false\r\n";
            ConfigInfo += "report_topology_graph_adjacency_matrix: false\r\n";
            ConfigInfo += "report_routing_table: false\r\n";
            ConfigInfo += "report_possible_routes: false\r\n";
            ConfigInfo += "report_routes_stats: false\r\n";
            ConfigInfo += "report_topology_sub_graph: false\r\n";
            ConfigInfo += "report_topology_sub_graph_adjacency_matrix: false\r\n";
            ConfigInfo += "report_sub_routing_table: false\r\n";
            ConfigInfo += "report_cycle_result: false\r\n";
            ConfigInfo += "report_flit_trace: false\r\n";

            ConfigInfo += "clock_period_ps: 1000\r\n";
            ConfigInfo += "reset_time: 1000\r\n";
            ConfigInfo += "simulation_time: " + SimulationTime + "\r\n";
            ConfigInfo += "stats_warm_up_time: " + WarmUpTime + "\r\n";

            ConfigInfo += "traffic_distribution: TRAFFIC_RANDOM\r\n";

            File.WriteAllText(ConfigFilePath, ConfigInfo);
        }

        public string[,] CollectSimulationResults()
        {
            int CharacteristicsAmount = 15;

            int TotalProducedFlitsLine = 2;
            int TotalProducedFlitsIndex = 0;

            int TotalAcceptedFlitsLine = 3;
            int TotalAcceptedFlitsIndex = 1;

            int TotalReceivedFlitsLine = 4;
            int TotalReceivedFlitsIndex = 2;

            int NetworkProductionLine = 5;
            int NetworkProductionIndex = 3;

            int NetworkAcceptanceLine = 6;
            int NetworkAcceptanceIndex = 4;

            int NetworkThroughputLine = 7;
            int NetworkThroughputIndex = 5;

            int IpThroughputLine = 8;
            int IpThroughputIndex = 6;

            int LastTimeFlitReceivedLine = 9;
            int LastTimeFlitReceivedIndex = 7;

            int MaxBufferStuckDelayLine = 10;
            int MaxBufferStuckDelayIndex = 8;

            int MaxTimeFlitInNetworkLine = 11;
            int MaxTimeFlitInNetworkIndex = 9;

            int TotalReceivedPacketsLine = 12;
            int TotalReceivedPacketsIndex = 10;

            int TotalFlitsLostLine = 13;
            int TotalFlitsLostIndex = 11;

            int GlobalAverageDelayLine = 14;
            int GlobalAverageDelayIndex = 12;

            int MaxDelayLine = 15;
            int MaxDelayIndex = 13;

            int AverageBufferUtilizationLine = 16;
            int AverageBufferUtilizationIndex = 14;

            int SectionsAmount = 0;

            string[] ResultSections = File.ReadAllLines(ResultsDirectoryPath + "\\" + DefaultResultFileName);
            foreach (string ResultString in ResultSections)
            {
                if (ResultString.Contains(ResultSectionHeader))
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
                if (ResultString.Contains(ResultSectionHeader))
                {
                    SectionIndex++;
                    SectionLineIndex = 0;
                    InSection = true;
                }
                else if (SectionLineIndex == TotalProducedFlitsLine && InSection)
                {
                    Result[SectionIndex, TotalProducedFlitsIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == TotalAcceptedFlitsLine && InSection)
                {
                    Result[SectionIndex, TotalAcceptedFlitsIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == TotalReceivedFlitsLine && InSection)
                {
                    Result[SectionIndex, TotalReceivedFlitsIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == NetworkProductionLine && InSection)
                {
                    Result[SectionIndex, NetworkProductionIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == NetworkAcceptanceLine && InSection)
                {
                    Result[SectionIndex, NetworkAcceptanceIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == NetworkThroughputLine && InSection)
                {
                    Result[SectionIndex, NetworkThroughputIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == IpThroughputLine && InSection)
                {
                    Result[SectionIndex, IpThroughputIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == LastTimeFlitReceivedLine && InSection)
                {
                    Result[SectionIndex, LastTimeFlitReceivedIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == MaxBufferStuckDelayLine && InSection)
                {
                    Result[SectionIndex, MaxBufferStuckDelayIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == MaxTimeFlitInNetworkLine && InSection)
                {
                    Result[SectionIndex, MaxTimeFlitInNetworkIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == TotalReceivedPacketsLine && InSection)
                {
                    Result[SectionIndex, TotalReceivedPacketsIndex] = ExtractValue(ResultString);                    
                }
                else if (SectionLineIndex == TotalFlitsLostLine && InSection)
                {
                    Result[SectionIndex, TotalFlitsLostIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == GlobalAverageDelayLine && InSection)
                {
                    Result[SectionIndex, GlobalAverageDelayIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == MaxDelayLine && InSection)
                {
                    Result[SectionIndex, MaxDelayIndex] = ExtractValue(ResultString);
                }
                else if (SectionLineIndex == AverageBufferUtilizationLine && InSection)
                {
                    Result[SectionIndex, AverageBufferUtilizationIndex] = ExtractValue(ResultString);
                    InSection = false;
                }

                SectionLineIndex++;
            }

            return Result;
        }

        private string ExtractValue(string TxtString)
        {
            string[] StringParts = TxtString.Split(':');
            string Value = StringParts[StringParts.Length - 1].Trim();

            return Value;
        }

    }
}
