using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YQED3S.Payment;
using Application = System.Windows.Forms.Application;

namespace YQED3S
{
    public partial class MainForm : Form
    {
        private Loader _loader;
        private List<Work> works; 

        public MainForm()
        {
            InitializeComponent();
            _loader = new Loader();

            // Subscribe to the Load event of MainForm
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initially disable menu items that require loaded works
            worksheetToolStripMenuItem.Enabled = false;
            paymentToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // var result = MessageBox.Show("Are you sure you want to quit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (result == DialogResult.Yes) 
            //{
              // Application.Exit();
            //}
            Close();
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Title = "Select a Text File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Load the file using the Loader class
                works = _loader.LoadFile(filePath);

                // Process the selected file
                MessageBox.Show($"Selected file: {filePath}", "File Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Enable menu items that require loaded works
            worksheetToolStripMenuItem.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string neptunCode = "YQED3S";
            string currentDate = DateTime.Now.ToString("yyyy.MM.dd");

            string message = $"Current Date: {currentDate}\nNeptun Code: {neptunCode}\n";

            MessageBox.Show(message, "About", MessageBoxButtons.OK);
        }

        private void worksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if works is not null or empty before opening the form
            if (works != null && works.Any())
            {
                // Create an instance of WorksheetRegistrationForm and show it
                // Create an instance of WorksheetRegistrationForm and show it
                WorksheetRegistrationForm worksheetRegistrationForm = new WorksheetRegistrationForm(works);
                worksheetRegistrationForm.WorksheetRegistered += WorksheetRegistrationForm_WorksheetRegistered;
                worksheetRegistrationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No works available. Please load a file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of PaymentForm
            PaymentForm paymentForm = new PaymentForm();

            // Show the PaymentForm
            paymentForm.ShowDialog();
        }

        private void WorksheetRegistrationForm_WorksheetRegistered(object sender, EventArgs e)
        {
            paymentToolStripMenuItem.Enabled = true; // Enable payment menu item
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt confirmation message only if the form is being closed by the user
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the user clicked No
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel form closing
                }
            }
        }

    }
}
