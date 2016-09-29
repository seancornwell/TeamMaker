using System.Collections.Generic;

namespace TeamMakerEngine
{
	public interface IGrouper
	{
		List<PlayerGroup> Group (IEnumerable<PlayerGroup> playerGroups); 
	}
}