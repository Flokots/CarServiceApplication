using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQED3S
{
    public class Work
    {
        public string Name { get; }
        public int ExecutionTimeMinutes { get; }
        public int MaterialCost { get; }

        public Work(string name, int executionTimeMinutes, int materialCost)
        {
            Name = name;
            ExecutionTimeMinutes = executionTimeMinutes;
            MaterialCost = materialCost;
        }

        // Property to calculate hours from execution time in minutes
        public int ExecutionTimeHours
        {
            get { return ExecutionTimeMinutes / 60; }
        }

        // Property to calculate remaining minutes from execution time in minutes
        public int ExecutionTimeRemainingMinutes
        {
            get { return ExecutionTimeMinutes % 60; }
        }
    }
}
