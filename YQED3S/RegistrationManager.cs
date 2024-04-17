using System;

namespace YourNamespace
{
    public class RegistrationManager
    {
        // Instance properties to store registration data
        public int RegisteredWorksheetCount { get; private set; }
        public int RegisteredWorkCount { get; private set; }
        public int TotalMaterialCost { get; private set; }
        public int TotalServiceCost { get; private set; }
        public double TotalInvoicedServiceTime { get; private set; }

        // Constructor
        public RegistrationManager()
        {
            // Initialize properties
            ResetData();
        }

        // Method to register a worksheet
        public void RegisterWorksheet()
        {
            RegisteredWorksheetCount++;
        }

        // Method to register work
        public void RegisterWork(int registeredWorkCount)
        {
            RegisteredWorkCount+= registeredWorkCount;
        }

        // Method to add material cost
        public void AddMaterialCost(int cost)
        {
            TotalMaterialCost += cost;
        }

        // Method to add service cost
        public void AddServiceCost(int cost)
        {
            TotalServiceCost += cost;
        }

        // Method to add invoiced service time
        public void AddInvoicedServiceTime(double time)
        {
            TotalInvoicedServiceTime += time;
        }

        // Method to reset data
        public void ResetData()
        {
            RegisteredWorksheetCount = 0;
            RegisteredWorkCount = 0;
            TotalMaterialCost = 0;
            TotalServiceCost = 0;
            TotalInvoicedServiceTime = 0;
        }
    }
}
