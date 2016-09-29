using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TeamMakerEngine
{
	public class TeamMakerService
	{

		private readonly IParser _parser;
		private readonly int _teamSize;
		private readonly IEnumerable<IGrouper> _groupers;

		public TeamMakerService( IParser parser, int teamSize, IEnumerable<IGrouper> groupers )
		{
			_parser = parser;
			_teamSize = teamSize;
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
			var teams = playerGroups.Select( ( pg, i ) => new Team( i, pg ) ).ToList();

			return new ReadOnlyCollection<Team>( teams );
		}


	}
}
