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
        private Label materialCostTextLabel;
        private Label serviceCostTextLabel;
        private Label materialCostValueLabel;
        private Label serviceCostValueLabel;
        private Dictionary<CheckBox, Label> checkBoxTotalCostLabelMap; // Define a dictionary to map checkboxes to total cost labels

        public WorksheetRegistrationForm(List<Work> works)
        {
            InitializeComponent();
            this.works = works;
            checkBoxTotalCostLabelMap = new Dictionary<CheckBox, Label>(); // Initialize the dictionary

            PopulateWorkOptions();
        }

        private void PopulateWorkOptions()
        {
            int y = 20; // Initial y position for rows
            int rowHeight = 20; // Height of each row
            int spacing = 10; // Spacing between rows

            workPanel.Controls.Clear();

            // Header row
            Label materialCostHeaderLabel = CreateHeaderLabel("Material Costs", new Point(220, y));
            workPanel.Controls.Add(materialCostHeaderLabel);

            Label executionTimeHeaderLabel = CreateHeaderLabel("Time", new Point(320, y));
            workPanel.Controls.Add(executionTimeHeaderLabel);

            Label totalCostsHeaderLabel = CreateHeaderLabel("Total Costs", new Point(480, y));
            workPanel.Controls.Add(totalCostsHeaderLabel);

            y += rowHeight + spacing; // Increase y position for the first row

            // Work detail rows
            foreach (Work work in works)
            {
                Label nameLabelRow = CreateValueLabel(work.Name, new Point(20, y));
                workPanel.Controls.Add(nameLabelRow);

                Label materialCostLabel = CreateValueLabel($"{work.MaterialCost} Ft", new Point(220, y));
                workPanel.Controls.Add(materialCostLabel);

                int hours = work.ExecutionTimeHours;
                int minutes = work.ExecutionTimeRemainingMinutes;
                Label executionTimeLabel = CreateValueLabel($"{hours} hrs {minutes} mins", new Point(320, y));
                workPanel.Controls.Add(executionTimeLabel);

                CheckBox checkBox = new CheckBox();
                checkBox.Tag = work; // Store the associated work object with the checkbox
                checkBox.AutoSize = true;
                checkBox.Location = new Point(420, y + (rowHeight - checkBox.Height) / 2);
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                workPanel.Controls.Add(checkBox);

                Label totalCostLabel = CreateValueLabel("", new Point(480, y));
                workPanel.Controls.Add(totalCostLabel);

                // Map the checkbox to its respective total cost label
                checkBoxTotalCostLabelMap.Add(checkBox, totalCostLabel);

                y += rowHeight + spacing; // Increase y position for the next row
            }
            
            // Create the labels for material costs and service costs
            materialCostTextLabel = CreateValueLabel("Total Material Costs: ", new Point(20, 10));
            totalsPanel.Controls.Add(materialCostTextLabel);

            materialCostValueLabel = CreateHeaderLabel($"{totalMaterialCost} Ft", new Point(materialCostTextLabel.Right + 10, 10));
            materialCostValueLabel.ForeColor = Color.Green; // Set text color to green
            totalsPanel.Controls.Add(materialCostValueLabel);

            serviceCostTextLabel = CreateValueLabel("Total Service Costs:", new Point(materialCostValueLabel.Right + 50, 10));
            totalsPanel.Controls.Add(serviceCostTextLabel);

            serviceCostValueLabel = CreateHeaderLabel($"{totalServiceCost} Ft", new Point(serviceCostTextLabel.Right + 10, 10));
            serviceCostValueLabel.ForeColor = Color.Red; // Set text color to red
            totalsPanel.Controls.Add(serviceCostValueLabel);

            // Register button
            Button registerButton = new Button();
            registerButton.Text = "Register";
            registerButton.BackColor = Color.LightGray;
            registerButton.Location = new Point(serviceCostValueLabel.Right + 50, 10);
            registerButton.Click += RegisterButton_Click;
            totalsPanel.Controls.Add(registerButton);

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
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                Work work = checkBox.Tag as Work;
                int individualTotalCost = CalculateIndividualTotalCost(work.ExecutionTimeMinutes);
                // Update the total costs label for this specific work
                if (checkBoxTotalCostLabelMap.ContainsKey(checkBox))
                {
                    Label totalCostLabel = checkBoxTotalCostLabelMap[checkBox];
                    totalCostLabel.Text = $"{individualTotalCost} Ft";
                    totalCostLabel.Visible = true; // Show the label
                }
            }
            else
            {
                // Checkbox is unchecked, hide the total cost label
                if (checkBoxTotalCostLabelMap.ContainsKey(checkBox))
                {
                    Label totalCostLabel = checkBoxTotalCostLabelMap[checkBox];
                    totalCostLabel.Visible = false; // Hide the label
                }
            }

            CalculateTotalCosts(); // Recalculate total costs
        }


        private void CalculateTotalCosts()
        {
            totalMaterialCost = 0;
            double totalServiceCost = 0;

            foreach (Control control in workPanel.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    Work work = (Work)checkBox.Tag;
                    totalMaterialCost += work.MaterialCost;
                    totalServiceCost += CalculateServiceCost(work.ExecutionTimeMinutes);
                }
            }

            // Update total costs labels
            materialCostValueLabel.Text = $"{totalMaterialCost} Ft";
            serviceCostValueLabel.Text = $"{totalServiceCost} Ft";
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
