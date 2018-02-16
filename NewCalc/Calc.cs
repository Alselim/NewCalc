using NewCalc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewCalc
{
    class Calc
    {
        
        private IList<IOperation> operations { get; set; }

        public Calc()
        {
            operations = new List<IOperation>();

            Assembly asm = Assembly.GetExecutingAssembly();
            var types = asm.GetTypes();
            var typeOperation = typeof(IOperation);

            foreach (var item in types.Where(t => !t.IsAbstract && !t.IsInterface))
            {
                if (item.GetInterfaces().Any(t => t == typeOperation))
                {
                    var obj = Activator.CreateInstance(item);
                    var operation = obj as IOperation;
                    if (operation != null) operations.Add(operation);
                }
            }
        }
        public string[] GetOperationsName()
        {
            return operations.Select(a => a.Name).ToArray();
        }

        public double Exec(string name, double[] args)
        {
            var oper = operations.FirstOrDefault(o => o.Name == name);
            if (oper == null) return double.NaN;
            return oper.Exec(args);
        }
    }
}
