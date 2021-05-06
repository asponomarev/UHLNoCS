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
        public static string[] BooksimInjectionRates = new string[] {"0.005", "0.01", "0.01515", "0.02", "0.025", "0.0303", "0.0357",
                                                                     "0.04", "0.0455", "0.05", "0.0556", "0.0625", "0.0667", "0.0714",
                                                                     "0.0769", "0.0833", "0.0909", "0.0909", "0.1"};

        public static string[] BooksimSamplePeriods = new string[] {"48000", "24000", "15840", "12000", "9600", "7920", "6720",
                                                                     "6000", "5280", "4800", "4320", "3840", "3600", "3360",
                                                                     "3120", "2880", "2640", "2640", "2400"};

        public static string BooksimNextInjectionRate(int Iteration)
        {
            return BooksimInjectionRates[Iteration];
        }

        public static string BooksimNextSamplePeriod(int Iteration)
        {
            return BooksimSamplePeriods[Iteration];
        }

    }
}
