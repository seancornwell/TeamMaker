using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamMakerEngine.Test
{
	[TestClass]
	public class CsvParserTest
	{
		[TestMethod]
		public void ParseTest()
		{
			var parser = new CsvParser();
			var players = parser.Parse(@".\SampleFiles\SamplePlayers_Pre-1.csv");

			CollectionAssert.AllItemsAreNotNull(players);
			Assert.IsTrue(players.Any(), "No items found");
		}
	}
}
