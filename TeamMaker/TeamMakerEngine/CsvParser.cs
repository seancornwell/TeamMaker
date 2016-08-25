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
            List<Player> players = new List<Player>();

            using (TextFieldParser parser = new TextFieldParser(""))
            {
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true;

                // skip over header line.
                parser.ReadLine();

                int firstNameIndex = 0;
                int lastNameIndex = 1;
                int addressIndex = 2;
                int cityIndex = 3;
                int zipIndex = 4;
                int stateIndex = 5;
                int dobIndex = 6;
                int ageGroupIndex = 7;
                int allStarIndex = 8;
                int schoolNameIndex = 9;
                int gradeIndex = 10;
                int medicalIndex = 11;
                int specialRequestsIndex = 12;
                int buddyRequest1Index = 13;
                int buddyRequest2Index = 14;
                int headCoachRequestIndex = 15;
                int volunteersNeededIndex = 16;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (fields == null)
                        continue;

                    var player = new Player(
                        firstName: fields[firstNameIndex],
                        lastName: fields[lastNameIndex],
                        address: fields[addressIndex],
                        city: fields[cityIndex],
                        zip: fields[zipIndex],
                        state: fields[stateIndex],
                        dob: fields[dobIndex],
                        ageGroup: fields[ageGroupIndex],
                        allStar: fields[allStarIndex],
                        schoolName: fields[schoolNameIndex],
                        grade: fields[gradeIndex],
                        medical: fields[medicalIndex],
                        specialRequests: fields[specialRequestsIndex],
                        buddyRequest1: fields[buddyRequest1Index],
                        buddyRequest2: fields[buddyRequest2Index],
                        headCoachRequest: fields[headCoachRequestIndex],
                        volunteersNeeded: fields[volunteersNeededIndex]);

                    players.Add(player);
                    //create new player and assign properties here
                }
            }

            return players;
        }
    }
}
