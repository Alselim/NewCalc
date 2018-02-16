using NewCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalc.Operations
{
    class MulOperation : IOperation
    {
        public string Name => "mul";


        public double Exec(double[] args)
        {
            return args.Aggregate((x, y) => x * y);
        }
    }
}
