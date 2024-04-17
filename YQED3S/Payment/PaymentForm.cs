using System;
using System.Drawing;
using System.Windows.Forms;
using YourNamespace;

namespace YQED3S.Payment
{
    public partial class PaymentForm : Form
    {
        private readonly RegistrationManager registrationManager;

        public PaymentForm(RegistrationManager registrationManager)
        {
            InitializeComponent();
            this.registrationManager = registrationManager;
            InitializePaymentSummary();
            InitializePaymentButton();
        }

        private void InitializePaymentSummary()
        {
            // Retrieve data from the registration manager
            int registeredWorksheetCount = registrationManager.RegisteredWorksheetCount;
            int registeredWorkCount = registrationManager.RegisteredWorkCount;
            int totalMaterialCost = registrationManager.TotalMaterialCost;
            int totalServiceCost = registrationManager.TotalServiceCost;
            double totalInvoicedServiceTime = registrationManager.TotalInvoicedServiceTime;
            int totalAmountToPay = totalMaterialCost + totalServiceCost;

            // Create labels for displaying summarized data
            Label lblNumWorks = new Label();
            lblNumWorks.Text = $"Work Count:";
            lblNumWorks.AutoSize = true;
            lblNumWorks.Location = new Point(20, 20);
            Controls.Add(lblNumWorks);

            Label lblMaterialCost = new Label();
            lblMaterialCost.Text = $"Material Cost:";
            lblMaterialCost.AutoSize = true;
            lblMaterialCost.Location = new Point(20, 50);
            Controls.Add(lblMaterialCost);

            Label lblServiceCost = new Label();
            lblServiceCost.Text = $"Service Cost:";
            lblServiceCost.AutoSize = true;
            lblServiceCost.Location = new Point(20, 80);
            Controls.Add(lblServiceCost);

            Label lblNumWorksheets = new Label();
            lblNumWorksheets.Text = $"Registered Worksheets Count:";
            lblNumWorksheets.AutoSize = true;
            lblNumWorksheets.Location = new Point(20, 110);
            Controls.Add(lblNumWorksheets);

            Label lblTotalServiceTime = new Label();
            lblTotalServiceTime.Text = $"Total Invoiced Service Time:";
            lblTotalServiceTime.AutoSize = true;
            lblTotalServiceTime.Location = new Point(20, 140);
            Controls.Add(lblTotalServiceTime);

            Label lblTotalAmount = new Label();
            lblTotalAmount.Text = $"Total Amount to Pay:";
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(20, 170);
            Controls.Add(lblTotalAmount);

            // Create labels for displaying summarized values with custom colors and formatting
            Label lblNumWorksValue = new Label();
            lblNumWorksValue.Text = $"{registeredWorkCount} db";
            lblNumWorksValue.AutoSize = true;
            lblNumWorksValue.Location = new Point(lblNumWorks.Right + 10, 20);
            lblNumWorksValue.ForeColor = Color.Orange; // Orange color for work count value
            lblNumWorksValue.Font = new Font(lblNumWorksValue.Font, FontStyle.Bold); // Bold font
            lblNumWorksValue.Font = new Font(lblNumWorksValue.Font.FontFamily, 10); // Larger font size
            Controls.Add(lblNumWorksValue);

            Label lblMaterialCostValue = new Label();
            lblMaterialCostValue.Text = $"{totalMaterialCost} Ft";
            lblMaterialCostValue.AutoSize = true;
            lblMaterialCostValue.Location = new Point(lblMaterialCost.Right + 10, 50);
            lblMaterialCostValue.ForeColor = Color.Green; // Green color for material cost value
            lblMaterialCostValue.Font = new Font(lblMaterialCostValue.Font, FontStyle.Bold); // Bold font
            lblMaterialCostValue.Font = new Font(lblMaterialCostValue.Font.FontFamily, 10); // Larger font size
            Controls.Add(lblMaterialCostValue);

            Label lblServiceCostValue = new Label();
            lblServiceCostValue.Text = $"{totalServiceCost} Ft";
            lblServiceCostValue.AutoSize = true;
            lblServiceCostValue.Location = new Point(lblServiceCost.Right + 10, 80);
            lblServiceCostValue.ForeColor = Color.Red; // Red color for service cost value
            lblServiceCostValue.Font = new Font(lblServiceCostValue.Font, FontStyle.Bold); // Bold font
            lblServiceCostValue.Font = new Font(lblServiceCostValue.Font.FontFamily, 10); // Larger font size
            Controls.Add(lblServiceCostValue);

            Label lblNumWorksheetsValue = new Label();
            lblNumWorksheetsValue.Text = $"{registeredWorksheetCount} db";
            lblNumWorksheetsValue.AutoSize = true;
            lblNumWorksheetsValue.Location = new Point(lblNumWorksheets.Right + 10, 110);
            lblNumWorksheetsValue.Font = new Font(lblNumWorksheetsValue.Font, FontStyle.Bold); // Bold font
            lblNumWorksheetsValue.Font = new Font(lblNumWorksheetsValue.Font.FontFamily, 10); // Larger font size
            Controls.Add(lblNumWorksheetsValue);

            Label lblTotalServiceTimeValue = new Label();
            lblTotalServiceTimeValue.Text = $"{totalInvoicedServiceTime} hours";
            lblTotalServiceTimeValue.AutoSize = true;
            lblTotalServiceTimeValue.Location = new Point(lblTotalServiceTime.Right + 10, 140);
            lblTotalServiceTimeValue.Font = new Font(lblTotalServiceTimeValue.Font, FontStyle.Bold); // Bold font
            lblTotalServiceTimeValue.Font = new Font(lblTotalServiceTimeValue.Font.FontFamily, 10); // Larger font size
            Controls.Add(lblTotalServiceTimeValue);

            Label lblTotalAmountValue = new Label();
            lblTotalAmountValue.Text = $"{totalAmountToPay} Ft";
            lblTotalAmountValue.AutoSize = true;
            lblTotalAmountValue.Location = new Point(lblTotalAmount.Right + 10, 170);
            lblTotalAmountValue.ForeColor = Color.Purple; // Purple color for total amount to pay value
            lblTotalAmountValue.Font = new Font(lblTotalAmountValue.Font, FontStyle.Bold); // Bold font
            lblTotalAmountValue.Font = new Font(lblTotalAmountValue.Font.FontFamily, 10); // Larger font size
            Controls.Add(lblTotalAmountValue);
        }

        private void InitializePaymentButton()
        {
            // Create and configure the payment button
            Button paymentButton = new Button();
            paymentButton.Text = "Pay Now";
            paymentButton.ForeColor = Color.White;
            paymentButton.BackColor = Color.FromArgb(0, 123, 255);
            paymentButton.Font = new Font("Arial", 10, FontStyle.Bold);
            paymentButton.Size = new Size(100, 30);
            paymentButton.Location = new Point(20, 220);

            // Wire up the event handler for the payment button
            paymentButton.Click += PaymentButton_Click;

            // Add the payment button to the form's controls
            Controls.Add(paymentButton);
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            // Process payment
            if (HasItemsToPay())
            {
                // Display payment confirmation message
                MessageBox.Show("Payment successful.", "Payment Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset the data
                ResetData();

                // Close the form
                this.Close();
            }
            else
            {
                // Display a message indicating there is nothing to pay
                MessageBox.Show("There are no registered worksheets to pay for.", "Payment Not Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Close the form
                this.Close();
            }
        }

        private bool HasItemsToPay()
        {
            // Check if any of the values are greater than zero
            return registrationManager.RegisteredWorksheetCount > 0 ||
                registrationManager.RegisteredWorkCount > 0 ||
                registrationManager.TotalMaterialCost > 0 ||
                registrationManager.TotalServiceCost > 0 ||
                registrationManager.TotalInvoicedServiceTime > 0;
        }
      
        private void ResetData()
        {
            // Reset data in the registration manager
            registrationManager.ResetData();
        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Reset all data to zero
            ResetData();
        }



    }
}
