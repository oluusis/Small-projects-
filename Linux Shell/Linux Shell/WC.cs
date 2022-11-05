using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linux_Shell
{
    public class WC
    {
        public void WriteCWL(string filePath, string? attribut)
        {
            try
            {
                int countCharacters = 0, countWords = 0, countLine = 0;
                string line = "";

                StreamReader sr = new StreamReader(filePath);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    countCharacters += line.Length;
                    countWords += line.Trim().Split(' ').Length;
                    countLine++;
                }
                sr.Close();

                string fileName = Path.GetFileName(filePath);
                string output;

                switch (attribut)
                {
                    case null:
                        output = $"Lines: {countLine}, Words: {countWords}, Characters: {countCharacters} {fileName}";
                        break;
                    case "-l":
                        output = $"Lines: {countLine} {fileName}";
                        break;
                    case "-w":
                        output = $"Words: {countWords} {fileName}";
                        break;
                    case "-c":
                        output = $"Characters: {countCharacters} {fileName}";
                        break;
                    default:
                        output = $"Attribut was not found";
                        break;
                }
                Console.WriteLine(output);
            }
            catch { }
        }

    }
}
