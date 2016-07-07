using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMakerEngine
{
    class CsvParser : IParser
    {
        public List<Player> Parse(string filepath)
        {
            using (TextFieldParser parser = new TextFieldParser(""))
            {
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true;

                // skip over header line.
                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    //create new player and assign properties here
                }
            }

            return null;
        }
    }
}
