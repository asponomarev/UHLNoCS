using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Algorithms
{
    public class AlgorithmsTypes
    {
        public static string Dijkstra = "Dijkstra";
        public static string PO = "PO";
        public static string ROU = "ROU";
        public static string GreedyPromotion = "GP";
        public static string MeshYX = "YX";

        public static string[] MeshAlgotithms = new string[] { MeshYX, GreedyPromotion };
        public static string[] TorusAlgorithms = new string[] { "Default" };
        public static string[] CirculantAlgorithms = new string[] { Dijkstra, PO, ROU, GreedyPromotion };
    }
}
