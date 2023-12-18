using System;
using System.Text;
const char SEPARATOR = ',';
// get file name from command line
string fileName = "123.csv";

// read file
string[] lines = File.ReadAllLines(fileName);

var result = new List<string>();

foreach (var line in lines)
{
    var processedLine = ProcessLine(line.Trim());
    result.Add(processedLine);
}

// write file
File.WriteAllLines("145.csv", result);

string ProcessLine(string line)
{
    var columns = line.Split(SEPARATOR);

    for (var i = 0; i < columns.Length; i++)
    {
        var column = columns[i];
        if (column == "4F" && columns.Length > i + 1)
        {
            columns[0] = columns[i];
            columns[1] = columns[i + 1];
            if (string.IsNullOrEmpty(columns[1])) { continue; }
            int result = CountValues(columns[1]);
            columns[2] = result.ToString();
        }

    }


    return string.Join(SEPARATOR, columns);
}
int CountValues(string s)
{
    int int_value = Convert.ToInt32("FFFF", 16);
    int int_value2 = Convert.ToInt32(s, 16);
    int output = (int_value - int_value2);
    return output;
}