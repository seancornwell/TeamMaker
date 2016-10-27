using System.Collections.Generic;
using System.Linq;

namespace TeamMakerEngine
{
	public class PlayerGroup
	{
		public PlayerGroup( Player player )
		{
			Players.Add(player);
		}

        public PlayerGroup( PlayerGroup playerGroup, IEnumerable<PlayerGroup> relatedPlayerGroups)
        {
            Players.AddRange(playerGroup.Players);
            Players.AddRange(relatedPlayerGroups.SelectMany(pg => pg.Players));
        }

		public List<Player> Players { get; } = new List<Player>();
        public string AvgBuddy => 
            Players?.Where(p => !string.IsNullOrWhiteSpace(p.BuddyRequest1))
            .GroupBy(p => p.BuddyRequest1)
            .OrderByDescending(pg => pg.Count())
            .FirstOrDefault()
            ?.Key;
		public string AvgCoach { get; set; }
		public string AvgSchool { get; set; }
		public int AvgAge  => Players?.Sum(p=> p.Age) ?? 0;
		public int AllStarCount => Players?.Count( p =>  p.IsAllStar ) ?? 0;
	}
}