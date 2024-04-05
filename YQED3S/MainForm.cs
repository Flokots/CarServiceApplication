﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                Application.Exit();
            }
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
                WorksheetRegistrationForm worksheetRegistrationForm = new WorksheetRegistrationForm(works);
                worksheetRegistrationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No works available. Please load a file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
