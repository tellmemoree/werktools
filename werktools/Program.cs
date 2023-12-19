using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

class Program
{
    const char SEPARATOR = ',';

    static void Main()
    {
        string fileName = @"/Users/valeriizubenko/Downloads/123.csv";
        string outputFile = @"/Users/valeriizubenko/Downloads/145.csv";

        string[] lines = File.ReadAllLines(fileName);
        var result = new List<string>();

        foreach (var line in lines)
        {
            var processedLine = ProcessLine(line.Trim());
            result.Add(processedLine);
        }

        File.WriteAllLines(outputFile, result);
    }

    static string ProcessLine(string line)
    {
        var columns = line.Split(SEPARATOR);
        var nonEmptyColumns = new List<string>();
        string delimeter = "FEFE"; // looking for delimiter

        for (var i = 0; i < columns.Length; i++)
        {
            var column = columns[i].Trim();

            // Check if the column is not empty and contains the desired delimiter
            if (!string.IsNullOrWhiteSpace(column) && column == delimeter)
            {
                // Add the non-empty column and the next column to the result list
                if (i < columns.Length - 1)
                {
                    nonEmptyColumns.Add(column);
                    nonEmptyColumns.Add(columns[i + 1].Trim());
                }
                i++; // Move to the next column as we've already processed the next column
            }
            else if (!string.IsNullOrWhiteSpace(column))
            {
                nonEmptyColumns.Add(column); // Add non-empty columns to the result list
            }
        }

        return string.Join(SEPARATOR, nonEmptyColumns);
    }
}
