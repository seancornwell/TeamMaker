using System.Collections.Generic;
using System.Linq;

namespace TeamMakerEngine
{
	public class CoachGrouper : IGrouper
	{
		public List<PlayerGroup> Group( IEnumerable<PlayerGroup> playerGroups )
		{
			return playerGroups.ToList();
		}
	}
}