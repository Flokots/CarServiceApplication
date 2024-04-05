using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQED3S
{
    internal class Work
    {
        public string Name { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public int MaterialCost { get; set; }

        public Work(string name, TimeSpan executionTime, int materialCost)
        {
            Name = name;
            ExecutionTime = executionTime;
            MaterialCost = materialCost;
        }
    }
}
