using System;
using System.Drawing;
using System.Windows.Forms;

namespace YQED3S.Payment
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();

            this.FormClosing += PaymentForm_FormClosing;

            int registeredWorksheetCount = RegistrationManager.RegisteredWorksheetCount;
            int registeredWorkCount = RegistrationManager.RegisteredWorkCount;
            int totalMaterialCost = RegistrationManager.TotalMaterialCost;
            int totalServiceCost = RegistrationManager.TotalServiceCost;
            double totalInvoicedServiceTime = RegistrationManager.TotalInvoicedServiceTime;
            int totalAmountToPay = totalMaterialCost + totalServiceCost;

            // Create labels for displaying summarized data
            Label lblNumWorks = new Label();
            lblNumWorks.Text = $"Work Count: {registeredWorkCount}";
            lblNumWorks.AutoSize = true;
            lblNumWorks.Location = new Point(20, 20);
            Controls.Add(lblNumWorks);

            Label lblMaterialCost = new Label();
            lblMaterialCost.Text = $"Material Cost: {totalMaterialCost} Ft";
            lblMaterialCost.AutoSize = true;
            lblMaterialCost.Location = new Point(20, 50);
            Controls.Add(lblMaterialCost);

            Label lblServiceCost = new Label();
            lblServiceCost.Text = $"Service Cost: {totalServiceCost} Ft";
            lblServiceCost.AutoSize = true;
            lblServiceCost.Location = new Point(20, 80);
            Controls.Add(lblServiceCost);

            Label lblNumWorksheets = new Label();
            lblNumWorksheets.Text = $"Registered Worksheets Count: {registeredWorksheetCount}";
            lblNumWorksheets.AutoSize = true;
            lblNumWorksheets.Location = new Point(20, 110);
            Controls.Add(lblNumWorksheets);

            Label lblTotalServiceTime = new Label();
            lblTotalServiceTime.Text = $"Total Invoiced Service Time: {totalInvoicedServiceTime} hours";
            lblTotalServiceTime.AutoSize = true;
            lblTotalServiceTime.Location = new Point(20, 140);
            Controls.Add(lblTotalServiceTime);

            Label lblTotalAmount = new Label();
            lblTotalAmount.Text = $"Total Amount to Pay: {totalAmountToPay} Ft";
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(20, 170);
            Controls.Add(lblTotalAmount);
        }

        // Add this event handler to handle form closing
        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Reset all data to zero
            ResetData();
        }

        private void ResetData()
        {
            // Reset all relevant data to zero
            RegistrationManager.RegisteredWorksheetCount = 0;
            RegistrationManager.RegisteredWorkCount = 0;
            RegistrationManager.TotalMaterialCost = 0;
            RegistrationManager.TotalServiceCost = 0;
            RegistrationManager.TotalInvoicedServiceTime = 0;
        }
    }
}
