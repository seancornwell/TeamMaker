using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamMakerEngine.Test.Mocks;

namespace TeamMakerEngine.Test
{
	[TestClass]
	public class TeamMakerServiceTest
	{
		[TestMethod]
		public void ProcessTest()
		{
			var parser = new CsvParser();
			var service = new TeamMakerService( parser, 12, new[] { new FakeGrouper() } );

			var teams = service.Process( @".\SampleFiles\SamplePlayers_Pre-1.csv" );

			Assert.AreEqual( 119, teams.Count );
		}
	}
}
