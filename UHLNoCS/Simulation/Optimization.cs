using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHLNoCS.Models;

namespace UHLNoCS.Simulation
{
    class Optimization
    {
        public static string ConstantStep(int IterationNumber, string StartInjectionRate)
        {
            double StartRate = double.Parse(StartInjectionRate, CultureInfo.InvariantCulture);
            double NextRate = StartRate * (IterationNumber + 1);

            return NextRate.ToString().Replace(',', '.');
        }

    }
}
