using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalc.Interfaces
{
    public interface IOperation
    {
        string Name { get; }

        double Exec(double[] args);
    }
    public interface ISuperOperation : IOperation
    {
        string Owner { get; set; }
        DateTime DateCreate { get; set; }
    }
}
