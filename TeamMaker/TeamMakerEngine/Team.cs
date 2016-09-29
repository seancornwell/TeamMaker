using System.Collections.ObjectModel;

namespace TeamMakerEngine
{
	public class Team
	{
		public Team( int teamId, PlayerGroup playerGroup )
		{
			TeamId = teamId;
			Players = new ReadOnlyCollection<Player>( playerGroup.Players );
		}


		public int TeamId { get; }
		public ReadOnlyCollection<Player> Players { get; }
	}
}