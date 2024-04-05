using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQED3S
{
    public class Parser
    {
        public Work Parse(string[] columns)
        {
            if (columns.Length == 3)
            {
                string name = columns[0];
                int executionTimeMinutes = int.Parse(columns[1]);
                int materialCost = int.Parse(columns[2]);

                return new Work(name, executionTimeMinutes, materialCost);
            }
            else
            {
                throw new ArgumentException("Invalid number of columns.");
            }
        }
    }
}
