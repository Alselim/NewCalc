using NewCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalc.Operations
{
    class SumOperation : IOperation
    {
        public string Name => "sum";


        public double Exec(double[] args)
        {
            return args.Sum();
        }
    }
}
