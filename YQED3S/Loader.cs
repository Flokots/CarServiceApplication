using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQED3S
{
    public class Loader
    {
        private readonly Parser _parser;
        private readonly List<Work> _works;

        public Loader()
        {
            _parser = new Parser();
            _works = new List<Work>();
        }

        public List<Work> LoadFile(string filePath)
        {
            try
            {
                // Clear any previously loaded works
                _works.Clear();

                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Parse each line and create Work instances
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');

                    // Ensure the line has the expected number of parts
                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        int executionTime = int.Parse(parts[1]);
                        int materialCost = int.Parse(parts[2]);

                        Work work = new Work(name, executionTime, materialCost);
                        _works.Add(work);
                    }
                    else
                    {
                        // Handle invalid line format (e.g., log an error, skip the line)
                        Console.WriteLine($"Invalid line format: {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }

            return _works;
        }
    }
}
