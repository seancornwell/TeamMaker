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

            var service = new TeamMakerService(parser);

            var message = service.Process(filepath);

            Console.WriteLine(message);

            Console.ReadLine();



            //ask for file path, receive file, run parser, produce while loop showing first names, end with realine that will close program when pressed
		}
	}
}
