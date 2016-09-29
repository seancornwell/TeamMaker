using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMakerEngine
{
	public class TeamMakerService
	{

		private IParser _parser;
		private readonly IEnumerable<IGrouper> _groupers;

		public TeamMakerService( IParser parser, IEnumerable<IGrouper> groupers )
		{
			_parser = parser;
			_groupers = groupers;
		}

		public ReadOnlyCollection<Team> Process( string inputFilePath )
		{
			var players = _parser.Parse( inputFilePath );
			var playerGroups = players.Select( p => new PlayerGroup( p ) ).ToList();

			foreach ( IGrouper grouper in _groupers )
			{
				playerGroups = grouper.Group( playerGroups );
			}

			var teams = playerGroups.Select((pg, i)=> new Team(i, pg)).ToList();

			return new ReadOnlyCollection<Team>(teams);
		}


	}
}
