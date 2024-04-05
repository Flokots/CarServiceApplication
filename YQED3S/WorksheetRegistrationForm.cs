using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YQED3S
{
    public partial class WorksheetRegistrationForm : Form
    {
        private List<Work> works;
        private int totalMaterialCost;
        private int totalServiceCost;
        private int totalIndividualCost;
        private Label totalMaterialCostLabel;
        private Label totalServiceCostLabel;

        public WorksheetRegistrationForm(List<Work> works)
        {
            InitializeComponent();
            this.works = works;

            PopulateWorkOptions();
        }

        private void PopulateWorkOptions()
        {
            int y = 20; // Initial y position for rows
            int rowHeight = 20; // Height of each row
            int spacing = 10; // Spacing between rows

            // Header row
            Label materialCostHeaderLabel = CreateHeaderLabel("Material Costs", new Point(220, y)); // Adjust spacing for even distribution
            Controls.Add(materialCostHeaderLabel);

            Label executionTimeHeaderLabel = CreateHeaderLabel("Time", new Point(320, y)); // Adjust spacing for even distribution
            Controls.Add(executionTimeHeaderLabel);

            Label totalCostsHeaderLabel = CreateHeaderLabel("Total Costs", new Point(480, y)); // Adjust spacing for even distribution
            Controls.Add(totalCostsHeaderLabel);

            y += rowHeight + spacing; // Increase y position for the first row

            // Work detail rows
            foreach (Work work in works)
            {
                Label nameLabelRow = CreateValueLabel(work.Name, new Point(20, y));
                Controls.Add(nameLabelRow);

                Label materialCostLabel = CreateValueLabel($"{work.MaterialCost} Ft", new Point(220, y)); // Adjust spacing for even distribution
                Controls.Add(materialCostLabel);

                int hours = work.ExecutionTimeHours;
                int minutes = work.ExecutionTimeRemainingMinutes;
                Label executionTimeLabel = CreateValueLabel($"{hours} hrs {minutes} mins", new Point(320, y)); // Adjust spacing for even distribution
                Controls.Add(executionTimeLabel);

                CheckBox checkBox = new CheckBox();
                checkBox.Tag = work; // Store the associated work object with the checkbox
                checkBox.AutoSize = true;
                checkBox.Location = new Point(420, y + (rowHeight - checkBox.Height) / 2); // Adjust spacing for even distribution
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                Controls.Add(checkBox);

                totalIndividualCost = CalculateIndividualTotalCost(work.ExecutionTimeMinutes);
                Label totalCostLabel = CreateValueLabel($"{totalIndividualCost} Ft", new Point(480, y)); // Adjust spacing for even distribution
                Controls.Add(totalCostLabel);

                y += rowHeight + spacing; // Increase y position for the next row
            }

            // Total costs labels
            totalMaterialCostLabel = CreateHeaderLabel($"Total Material Costs: {totalMaterialCost} Ft", new Point(20, y + spacing));
            Controls.Add(totalMaterialCostLabel);

            totalServiceCostLabel = CreateHeaderLabel($"Total Service Costs: {totalServiceCost} Ft", new Point(totalMaterialCostLabel.Right + 100, y + spacing)); // Adjust spacing for even distribution
            Controls.Add(totalServiceCostLabel);

            // Register button
            Button registerButton = new Button();
            registerButton.Text = "Register";
            registerButton.Location = new Point(totalServiceCostLabel.Right + 70, y + spacing); // Adjust spacing for even distribution
            registerButton.Click += RegisterButton_Click;
            Controls.Add(registerButton);
        }

        private Label CreateHeaderLabel(string text, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Font = new Font(label.Font, FontStyle.Bold);
            label.Location = location;
            return label;
        }

        private Label CreateValueLabel(string text, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            label.Location = location;
            return label;
        }
        
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotalCosts();
            
        }

        private void CalculateTotalCosts()
        {
            totalMaterialCost = 0;
            double totalServiceCost = 0;

            foreach (Control control in Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    Work work = (Work)checkBox.Tag;
                    totalMaterialCost += work.MaterialCost;
                    totalServiceCost += CalculateServiceCost(work.ExecutionTimeMinutes);
                }
            }

            // Update total costs labels
            totalMaterialCostLabel.Text = $"Total Material Costs: {totalMaterialCost} Ft";
            totalServiceCostLabel.Text = $"Total Service Costs: {totalServiceCost} Ft";
        }
        
        private int CalculateIndividualTotalCost(int timeInMinutes)
        {
            // Convert minutes to hours
            float hours = timeInMinutes / 60f;

            // Calculate total cost
            int totalCost = (int)(hours * 15000); // Assuming 1 work hour costs 15000 HUF

            return totalCost;
        }

        private double CalculateServiceCost(int timeInMinutes)
        {
            int hours = timeInMinutes / 60;
            int minutes = timeInMinutes % 60;

            // Calculate the total hours, considering the minutes
            double totalHours = hours;

            // Round up if there are more than 30 minutes
            if (minutes > 0 && minutes <= 30)
            {
                totalHours += 0.5f;
            }
            else if (minutes > 30 && minutes < 60)
            {
                totalHours += 1;
            }

            // Calculate the total cost
            return totalHours * 15000; // Assuming 1 work hour costs 15000 HUF
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // Register worksheet here
            // Optionally, perform validation before registering

            // Close the form
            this.Close();
        }

        private void WorksheetRegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the worksheet is registered
            if (totalMaterialCost == 0 && totalServiceCost == 0)
            {
                // Prompt confirmation message
                DialogResult result = MessageBox.Show("Are you sure you want to close without registering the worksheet?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel form closing
                }
            }
        }
    }
}
