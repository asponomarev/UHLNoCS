using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHLNoCS.Models;
using UHLNoCS.Simulation;

namespace UHLNoCS
{
    public partial class MainForm : Form
    {
        public void ControllerThreadTask()
        {
            DateTime SimulationStart = DateTime.Now;
            ToLogsTextBox("Controller thread started at " + SimulationStart.ToString());

            // Updating some GUI elements state
            Invoke(new Action(() =>
            {
                SimulationNameButton.Enabled = false;
                StartSimulationButton.Enabled = false;

                ModelAddButton.Enabled = false;
                DeleteModelButton.Enabled = false;
            }));

            // Starting ModelsThreads
            for (int ModelIndex = 0; ModelIndex < SimulationController.Models.Count; ModelIndex++)
            {
                Process ModelProcess = new Process();
                SimulationController.ModelsProcesses.Add(ModelProcess);

                Thread ModelThread = new Thread(ModelThreadTask);
                SimulationController.ModelsThreads.Add(ModelThread);
                SimulationController.ModelsThreads[ModelIndex].IsBackground = true;
                SimulationController.ModelsThreads[ModelIndex].Start(SimulationController.Models[ModelIndex].GetName());
            }

            // Waiting for all ModelsThreads to finish
            bool SimulationCompleted = false;
            while (!SimulationCompleted)
            {
                int NumberOfAliveModelThreads = 0;

                foreach (Thread ModelThread in SimulationController.ModelsThreads)
                {
                    if (ModelThread.IsAlive)
                    {
                        NumberOfAliveModelThreads++;
                    }
                }

                if (NumberOfAliveModelThreads == 0)
                {
                    SimulationCompleted = true;
                }

                Invoke(new Action(() =>
                {
                    UpdateTablesStates();
                    UpdateButtonsStates();
                }));

                if (!SimulationCompleted)
                {
                    Thread.Sleep(1000);
                }
            }

            DateTime SimulationEnd = DateTime.Now;
            ToLogsTextBox("Controller thread finished at " + SimulationEnd.ToString() + " in " + (SimulationEnd - SimulationStart).ToString());
        }

        public void ModelThreadTask(object ThreadObject)
        {
            string ModelName = (string)ThreadObject;
            int ModelIndex = SimulationController.FindModelIndex(ModelName);
            Model ThreadModel = SimulationController.FindModel(ModelName);

            ToLogsTextBox("Model " + ModelName + " thread started");

            // PREPARATION BEGIN
            ToLogsTextBox("Model " + ModelName + " preparation for simulation started");

            SimulationController.ModelsStates[ModelIndex][1] = State.Running;
            Invoke(new Action(() => { UpdateSimulationState(); }));

            Directory.CreateDirectory(ThreadModel.GetResultsDirectoryPath());

            string PreparationResult = "";
            try
            {
                if (ThreadModel.GetType() == ModelsTypes.UOCNS)
                {
                    UOCNS Uocns = (UOCNS)ThreadModel;
                    Uocns.PrepareForSimulation();
                }
                else if (ThreadModel.GetType() == ModelsTypes.Booksim)
                {
                    Booksim BookSim = (Booksim)ThreadModel;
                    BookSim.PrepareForSimulation();
                }

                PreparationResult = State.Completed;
            }
            catch (Exception PreparationException)
            {
                PreparationResult = State.Error;
                ToLogsTextBox("Model " + ModelName + " preparation for simulation " + PreparationResult.ToLower() + ": " + PreparationException.Message + PreparationException.StackTrace);
            }

            if (PreparationResult == State.Error)
            {
                SimulationController.ModelsStates[ModelIndex][1] = State.Error;
                SimulationController.ModelsStates[ModelIndex][2] = State.Stopped;
                SimulationController.ModelsStates[ModelIndex][3] = State.Stopped;
                Invoke(new Action(() => { UpdateSimulationState(); }));
                ToLogsTextBox("Model " + ModelName + " thread finished");
            }
            else
            {
                ToLogsTextBox("Model " + ModelName + " preparation for simulation " + PreparationResult.ToLower());
                // PREPARATION END

                // SIMULATION BEGIN
                ToLogsTextBox("Model " + ModelName + " simulation started");

                SimulationController.ModelsStates[ModelIndex][1] = State.Completed;
                SimulationController.ModelsStates[ModelIndex][2] = State.Running;
                Invoke(new Action(() => { UpdateSimulationState(); }));

                int ProcessExitCode = 0;
                bool ExceptionThrown = false;
                try
                {
                    if (ThreadModel.GetType() == ModelsTypes.UOCNS)
                    {
                        UOCNS Uocns = (UOCNS)ThreadModel;
                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.FileName = Uocns.GetExecutableFilePath();
                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.Arguments = Uocns.GetConfigFilePath() + " " + Uocns.GetResultsDirectoryPath();

                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.CreateNoWindow = true;

                        // SIMULATION PROCESS BEGIN
                        SimulationController.ModelsProcesses[ModelIndex].Start();
                        ToLogsTextBox("Model " + ModelName + " simulation process started");

                        SimulationController.ModelsProcesses[ModelIndex].WaitForExit();
                        ProcessExitCode = SimulationController.ModelsProcesses[ModelIndex].ExitCode;
                        ToLogsTextBox("Model " + ModelName + " simulation process finished with exit code " + ProcessExitCode.ToString());
                        // SIMULATION PROCESS END

                        SimulationController.ModelsProcesses[ModelIndex].Close();
                    }
                    else if (ThreadModel.GetType() == ModelsTypes.Booksim)
                    {
                        Booksim BookSim = (Booksim)ThreadModel;

                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.FileName = BookSim.GetExecutableFilePath();
                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.Arguments = BookSim.GetConfigFilePath();
                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.CreateNoWindow = true;
                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.UseShellExecute = false;
                        SimulationController.ModelsProcesses[ModelIndex].StartInfo.RedirectStandardOutput = true;

                        ToLogsTextBox("Model " + ModelName + " simulation process started");

                        string OldInjectionRate = BookSim.GetInjectionRate();
                        string OldSamplePeriod = BookSim.GetSimulationPeriodLength();

                        string OldMaxSamples = BookSim.GetMaxPeriodsAmount();
                        string OldSimulationType = BookSim.GetSimulationType();

                        int Iteration = 0;
                        int IterationExitCode = 255;

                        ((Booksim)SimulationController.Models[ModelIndex]).SetSimulationType(Booksim.SimulationTypes[1]);
                        ((Booksim)SimulationController.Models[ModelIndex]).SetMaxPeriodsAmount(Booksim.DefaultMaxPeriodsAmount);

                        while (Iteration < Optimization.BooksimInjectionRates.Length && IterationExitCode == 255)
                        {
                            string InjectionRate = Optimization.BooksimNextInjectionRate(Iteration);
                            string SamplePeriod = Optimization.BooksimNextSamplePeriod(Iteration);

                            ((Booksim)SimulationController.Models[ModelIndex]).SetInjectionRate(InjectionRate);
                            ((Booksim)SimulationController.Models[ModelIndex]).SetSimulationPeriodLength(SamplePeriod);

                            ((Booksim)SimulationController.Models[ModelIndex]).PrepareForSimulation();

                            SimulationController.ModelsProcesses[ModelIndex].Start();

                            string IterationResult = SimulationController.ModelsProcesses[ModelIndex].StandardOutput.ReadToEnd();
                            SimulationController.ModelsProcesses[ModelIndex].WaitForExit();

                            IterationExitCode = SimulationController.ModelsProcesses[ModelIndex].ExitCode;
                            IterationResult = IterationResult.Substring(IterationResult.IndexOf(Booksim.BeforeSectionHeader));
                            IterationResult += "\r\nExit code " + IterationExitCode.ToString() + "\r\n";

                            if (Iteration == 0)
                            {
                                File.WriteAllText(BookSim.GetResultsDirectoryPath() + "\\" + Booksim.DefaultResultFileName, IterationResult);
                            }
                            else
                            {
                                File.AppendAllText(BookSim.GetResultsDirectoryPath() + "\\" + Booksim.DefaultResultFileName, IterationResult);
                            }

                            Iteration++;
                        }

                        ((Booksim)SimulationController.Models[ModelIndex]).SetSimulationType(OldSimulationType);
                        ((Booksim)SimulationController.Models[ModelIndex]).SetInjectionRate(OldInjectionRate);

                        ((Booksim)SimulationController.Models[ModelIndex]).SetMaxPeriodsAmount(OldMaxSamples);
                        ((Booksim)SimulationController.Models[ModelIndex]).SetSimulationPeriodLength(OldSamplePeriod);

                        ProcessExitCode = IterationExitCode;

                        ToLogsTextBox("Model " + ModelName + " simulation process finished with exit code " + ProcessExitCode.ToString());

                        SimulationController.ModelsProcesses[ModelIndex].Close();
                    }
                }
                catch (Exception SimulationException)
                {
                    ExceptionThrown = true;
                    ToLogsTextBox("Model " + ModelName + " simulation finished with error: " + SimulationException.Message + SimulationException.StackTrace);
                }

                if (ExceptionThrown || (ThreadModel.GetType() == ModelsTypes.UOCNS && ProcessExitCode != 0) || (ThreadModel.GetType() == ModelsTypes.Booksim && ProcessExitCode != 255))
                {
                    ToLogsTextBox("\r\nHere " + ProcessExitCode.ToString() + "\r\n");
                    SimulationController.ModelsStates[ModelIndex][2] = State.Error;
                    SimulationController.ModelsStates[ModelIndex][3] = State.Stopped;
                    Invoke(new Action(() => { UpdateSimulationState(); }));
                    if (!ExceptionThrown) { ToLogsTextBox("Model " + ModelName + " simulation finished"); }
                    ToLogsTextBox("Model " + ModelName + " thread finished");
                }
                else
                {
                    ToLogsTextBox("Model " + ModelName + " simulation finished");
                    // SIMULATION END

                    // COLLECTING RESULTS BEGIN
                    ToLogsTextBox("Model " + ModelName + " collecting results started");

                    SimulationController.ModelsStates[ModelIndex][2] = State.Completed;
                    SimulationController.ModelsStates[ModelIndex][3] = State.Running;
                    Invoke(new Action(() => { UpdateSimulationState(); }));

                    string CollectingResultsResult = "";
                    try
                    {
                        if (ThreadModel.GetType() == ModelsTypes.UOCNS)
                        {
                            UOCNS Uocns = (UOCNS)ThreadModel;
                            string[,] Result = Uocns.CollectSimulationResults();
                            Invoke(new Action(() => { FillResultsTables(ModelIndex, Result); }));
                        }
                        else if (ThreadModel.GetType() == ModelsTypes.Booksim)
                        {
                            Booksim BookSim = (Booksim)ThreadModel;
                            string[,] Result = BookSim.CollectSimulationResults();
                            Invoke(new Action(() => { FillResultsTables(ModelIndex, Result); }));
                        }

                        CollectingResultsResult = State.Completed;
                    }
                    catch (Exception CollectingResultsException)
                    {
                        CollectingResultsResult = State.Error;
                        ToLogsTextBox("Model " + ModelName + " collecting results " + CollectingResultsResult.ToLower() + ": " + CollectingResultsException.Message + CollectingResultsException.StackTrace);
                    }

                    if (CollectingResultsResult == State.Error)
                    {
                        SimulationController.ModelsStates[ModelIndex][3] = State.Error;
                    }
                    else
                    {
                        SimulationController.ModelsStates[ModelIndex][3] = State.Completed;
                        ToLogsTextBox("Model " + ModelName + " collecting results " + CollectingResultsResult.ToLower());
                    }

                    Invoke(new Action(() => { UpdateSimulationState(); }));
                    // COLLECTING RESULTS END

                    ToLogsTextBox("Model " + ModelName + " thread finished");
                } // if SIMULATION COMPLETED
            } // if PREPARATION COMPLETED           
        } // Task

        private void UpdateTablesStates()
        {
            // Updating SimulationStateTable
            for (int CellIndex = 0; CellIndex < SimulationController.SimulationState.Length; CellIndex++)
            {
                SimulationStateTable.Rows[0].Cells[CellIndex].Value = SimulationController.SimulationState[CellIndex];
            }

            // Updating ModelsStateTable
            for (int RowIndex = 0; RowIndex < SimulationController.ModelsStates.Count; RowIndex++)
            {
                for (int CellIndex = 1; CellIndex < SimulationController.ModelsStates[RowIndex].Length; CellIndex++)
                {
                    ModelsStateTable.Rows[RowIndex].Cells[CellIndex].Value = SimulationController.ModelsStates[RowIndex][CellIndex];
                }
            }
        }

        private void UpdateButtonsStates()
        {
            if (SimulationController.SimulationState[3] == State.Finished)
            {
                NewSimulationButton.Enabled = true;
            }

            if (SimulationController.SimulationState[2] == State.Finished)
            {
                StopSimulationButton.Enabled = false;
                StopModelButton.Enabled = false;
            }

            if (SimulationController.SimulationState[2] == State.InProgress)
            {
                StopSimulationButton.Enabled = true;
                StopModelButton.Enabled = true;
            }
        }

        private void UpdateSimulationState()
        {
            int NumberOfModels = SimulationController.Models.Count;
            List<string[]> ModelsStates = SimulationController.ModelsStates;
            int NumberOfStates = ModelsStates[0].Length;

            for (int StateIndex = 1; StateIndex < NumberOfStates; StateIndex++)
            {
                int NotStarted = 0;
                int Running = 0;
                int CompletedStoppedError = 0;

                for (int ModelIndex = 0; ModelIndex < NumberOfModels; ModelIndex++)
                {
                    string ModelState = ModelsStates[ModelIndex][StateIndex];

                    if (ModelState == State.NoState) { NotStarted++; }
                    if (ModelState == State.Running) { Running++; }
                    if (ModelState == State.Completed || ModelState == State.Stopped || ModelState == State.Error) { CompletedStoppedError++; }
                }

                if (NumberOfModels == NotStarted) { SimulationController.SimulationState[StateIndex] = State.NoState; }
                if (Running != 0) { SimulationController.SimulationState[StateIndex] = State.InProgress; }
                if (NumberOfModels == CompletedStoppedError) { SimulationController.SimulationState[StateIndex] = State.Finished; }
            }

            if (SimulationController.SimulationState[1] != State.NoState) { SimulationController.SimulationState[0] = State.Finished; }
        }

    }
}
