using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHLNoCS.Models
{
    public class Model
    {
        protected string Type;
        protected string Name;
        protected string ExecutableFilePath;
        protected string ResultsDirectoryPath;

        public Model(string NewType, string NewName, string NewExecutableFilePath, string NewResultsDirectoryPath)
        {
            Type = NewType;
            Name = NewName;
            ExecutableFilePath = NewExecutableFilePath;
            ResultsDirectoryPath = NewResultsDirectoryPath;
        }

        public void SetType(string NewType) { Type = NewType; }
        public new string GetType() { return Type; }

        public void SetName(string NewName) { Name = NewName; }
        public string GetName() { return Name; }

        public void SetExecutableFilePath(string NewExecutableFilePath) { ExecutableFilePath = NewExecutableFilePath; }
        public string GetExecutableFilePath() { return ExecutableFilePath; }

        public void SetResultsDirectoryPath(string NewResultsDirectoryPath) { ResultsDirectoryPath = NewResultsDirectoryPath; }
        public string GetResultsDirectoryPath() { return ResultsDirectoryPath; }

    }
}
