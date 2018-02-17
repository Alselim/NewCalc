using NewCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditOperation
{
    public class CreditOperation : ISuperOperation
    {
        public DateTime DateCreate => DateTime.Today;

        public string Name => "Credit";

        public string Owner => "Google";

        public double Exec(double[] args)
        {
            return args.Aggregate((x, y) => x * 1.11 / y);
        }
    }
}
