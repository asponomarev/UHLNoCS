using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UHLNoCS.Models;

namespace UHLNoCS
{
    class Controller
    {
        public string SimulationName;
        public List<Model> Models;
        public Thread ControllerThread;
        public List<Thread> ModelsThreads;
        public List<Process> ModelsProcesses;

        public Controller()
        {
            SimulationName = "NewSimulation";
            Models = new List<Model>();
            ControllerThread = null;
            ModelsThreads = new List<Thread>();
            ModelsProcesses = new List<Process>();
        }
        
        public Model FindModel(string WantedModelName)
        {
            foreach (Model ConnectedModel in Models)
            {
                if (ConnectedModel.GetName() == WantedModelName)
                {
                    return ConnectedModel;
                }
            }
            return null;
        }

        public int FindModelIndex(string WantedModelName)
        {
            for (int Index = 0; Index < Models.Count; Index++)
            {
                if (Models[Index].GetName() == WantedModelName)
                {
                    return Index;
                }
            }
            return -1;
        }

        public void DeleteModel(string UnwantedModelName)
        {
            foreach (Model ConnectedModel in Models)
            {
                if (ConnectedModel.GetName() == UnwantedModelName)
                {
                    Models.Remove(ConnectedModel);
                    return;
                }
            }
        }

    }
}
