using System.Collections.Generic;
using System.Linq;

namespace TeamMakerEngine.Test.Mocks
{
	public class FakeGrouper : IGrouper
	{
		public List<PlayerGroup> Group( IEnumerable<PlayerGroup> playerGroups )
		{
			return playerGroups.ToList();
		}
	}
}