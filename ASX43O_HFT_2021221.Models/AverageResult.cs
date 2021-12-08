using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASX43O_HFT_2021221.Models
{
    public class AverageResult
    {
        public string Name { get; private set; }
        public double Result { get; private set; }

        public AverageResult(string name, double result)
        {
            Name = name;
            Result = result;
        }
    }
}
