using System.Collections.Generic;
using System.Linq;

namespace TeamMakerEngine
{
	public class BuddyGrouper : IGrouper
	{
		public List<PlayerGroup> Group( IEnumerable<PlayerGroup> playerGroups )
		{
            var newPlayerGroups = new List<PlayerGroup>();

            var groupRequests = playerGroups.GroupBy(pg => pg.AvgBuddy);

            var noRequests = groupRequests.First(g => g.Key == null);

            newPlayerGroups.AddRange(noRequests);

            List <PlayerGroup> withRequests = groupRequests.Where(g => g.Key != null).Select(g => new PlayerGroup(g)).ToList();
            while (withRequests.Any())
            {
                var grouping = withRequests.First();
                withRequests.Remove(grouping);

                var requestedBuddy = grouping.AvgBuddy;

                bool alreadyContainsBuddy = grouping.Players.Any(p => p.FullName == requestedBuddy);

                if (alreadyContainsBuddy)
                {
                    continue;
                }

                var foundGroup1 = withRequests.FirstOrDefault(pg => pg.Players.Any(p => p.FullName == requestedBuddy));

                //

                var foundGroup = newPlayerGroups.FirstOrDefault(pg => pg.Players.Any(p => p.FullName == requestedBuddy));

                if (foundGroup == null)
                {
                    // todo-find buddy in other groups
                }
                else
                {
                    newPlayerGroups.Remove(foundGroup);
                    var newGroup = new PlayerGroup(foundGroup, grouping);

                    newPlayerGroups.Add(newGroup);
                }
            }

			return newPlayerGroups;
		}
        
	}
}