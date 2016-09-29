using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamMakerEngine;

namespace TeamMakerHost
{
	class Program
	{
		static void Main( string[] args )
		{
            Console.WriteLine("What is the file path, including the file name, for your team .csv file?");

            var filepath = Console.ReadLine();

            var parser = new CsvParser();

            int teamSize;

            do
            {
                Console.WriteLine("How many players would you like on each team?");

                var teamSizeStr = Console.ReadLine();
                int.TryParse(teamSizeStr, out teamSize);
            } while (teamSize != 0);

            var service = new TeamMakerService(parser,teamSize);

            var message = service.Process(filepath);

            Console.WriteLine(message);

            Console.ReadLine();



            //ask for file path, receive file, run parser, produce while loop showing first names, end with realine that will close program when pressed
		}
	}
}
