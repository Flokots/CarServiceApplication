using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YQED3S
{
    public class Loader
    {
        private readonly Parser _parser;

        public Loader()
        {
            _parser = new Parser();
        }

        public List<Work> LoadFile(string filePath)
        {
            List<Work> works = new List<Work>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] columns = line.Split(';');
                    Work work = _parser.Parse(columns);
                    works.Add(work);
                }
            }
            catch (Exception ex)
            {
                // Handle file loading errors, e.g., file not found, invalid format
                Console.WriteLine($"Error loading file: {ex.Message}");
            }

            return works;
        }
    }
}
