using System;
using System.Text;
const char SEPARATOR = ',';
// get file name from command line
string fileName = @"/Users/valeriizubenko/Downloads/123.csv";

// read file
string[] lines = File.ReadAllLines(fileName);

var result = new List<string>();

foreach (var line in lines)
{
    var processedLine = ProcessLine(line.Trim());
    result.Add(processedLine);
}

// write file
File.WriteAllLines("/Users/valeriizubenko/Downloads/145.csv", result);

string ProcessLine(string line)
{
    var columns = line.Split(SEPARATOR);
    string deviceType = "0D"; // setting the deviceType to look for

    // for loop to start looking for things
    for (var i = 1; i < columns.Length; i++)
    {
        var column = columns[i];
        if (column == deviceType && columns.Length > i)
        {
            var temp0 = columns[i];
            var temp1 = columns[i + 1];

            for (var x = 1; x < columns.Length; x += 2)
            {
                var shoe = columns[x];
                
                if (shoe != deviceType && columns.Length > x + 1)
                {
                    columns[x] = temp0;
                    columns[x+1] = temp1;

                    break;
                }
            }
        }
    }
    return string.Join(SEPARATOR, columns);
}