using System;
using System.Collections.Generic;
using System.IO;

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

                    // Use the parser to parse the parts into a Work object
                    try
                    {
                        Work work = _parser.Parse(parts);
                        _works.Add(work);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Invalid line format: {line} ({ex.Message})");
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
