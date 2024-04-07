using System;

namespace YQED3S
{
    public class Work
    {
        // Private data members
        private readonly string name;
        private readonly int executionTimeMinutes;
        private readonly int materialCost;

        // Automatic properties with readonly backing fields
        public string Name => name;
        public int ExecutionTimeMinutes => executionTimeMinutes;
        public int MaterialCost => materialCost;

        // Constructor to initialize the automatic properties
        public Work(string name, int executionTimeMinutes, int materialCost)
        {
            this.name = name;
            this.executionTimeMinutes = executionTimeMinutes;
            this.materialCost = materialCost;
        }

        // Property to calculate hours from execution time in minutes
        public int ExecutionTimeHours => ExecutionTimeMinutes / 60;

        // Property to calculate remaining minutes from execution time in minutes
        public int ExecutionTimeRemainingMinutes => ExecutionTimeMinutes % 60;
    }
}
