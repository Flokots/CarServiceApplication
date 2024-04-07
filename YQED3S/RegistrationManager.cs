using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQED3S
{
    public static class RegistrationManager
    {
        public static int RegisteredWorksheetCount { get; set; }
        public static int RegisteredWorkCount { get; set; }
        public static int TotalMaterialCost { get; set; }
        public static int TotalServiceCost { get; set; }
        public static double TotalInvoicedServiceTime { get; set; }
    }
}
