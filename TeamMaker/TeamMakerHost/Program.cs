using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TeamMakerEngine;

namespace TeamMakerHost
{
	class Program
	{
		static void Main( string[] args )
		{
			Console.WriteLine( "What is the file path, including the file name, for your team .csv file?" );

			var filepath = Console.ReadLine();

			int teamSize;
			do
			{
				Console.WriteLine( "How many players would you like on each team?" );

				var teamSizeStr = Console.ReadLine();
				int.TryParse( teamSizeStr, out teamSize );
			} while ( teamSize == 0 );

			var parser = new CsvParser();
			var service = new TeamMakerService( parser, teamSize, new IGrouper[] { new BuddyGrouper(), new CoachGrouper(), new SchoolGrouper() } );

			ReadOnlyCollection<Team> teams = service.Process( filepath );

			//ask for file path, receive file, run parser, produce while loop showing first names, end with realine that will close program when pressed
			Console.WriteLine( teams.Count );

			Console.ReadLine();
		}
	}
}
