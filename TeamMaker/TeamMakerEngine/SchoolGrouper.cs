using System.Collections.Generic;
using System.Linq;

namespace TeamMakerEngine
{
	public class SchoolGrouper : IGrouper
	{
		public List<PlayerGroup> Group( IEnumerable<PlayerGroup> playerGroups )
		{
			return playerGroups.ToList();
		}
	}
}