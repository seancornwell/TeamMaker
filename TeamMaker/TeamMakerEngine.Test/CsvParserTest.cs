using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//TODO: Sean - Use this path for the data file: ".\SampleFiles\SamplePlayers_Pre-1.csv"
namespace TeamMakerEngine.Test
{
	[TestClass]
	public class CsvParserTest
	{
		[TestMethod]
		public void ParseTest()
		{
			var a = new CsvParser();
			var col = a.Parse(@"C:\Users\Sean\Downloads\FileNameFromFer.csv");

			CollectionAssert.AllItemsAreNotNull(col);
			Assert.IsTrue(col.Any(), "No items found");
		}
	}
}
