using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			Console.WriteLine( "What is the file path, including the file name, for your team .csv file?" );

			var filepath = Console.ReadLine();

			var parser = new CsvParser();

			var service = new TeamMakerService( parser, new List<IGrouper> { new BuddyGrouper(), new CoachGrouper(), new SchoolGrouper() } );

			ReadOnlyCollection<Team> teams = service.Process( filepath );

			Console.WriteLine( teams.Count );

			Console.ReadLine();



			//ask for file path, receive file, run parser, produce while loop showing first names, end with realine that will close program when pressed
		}
	}
}
