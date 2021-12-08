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
        public override bool Equals(object obj)
        {
            if (obj is AverageResult)
            {
                var other = obj as AverageResult;
                return this.Result == other.Result && this.Name == other.Name;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Result.GetHashCode();
        }
    }
}
