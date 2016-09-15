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
			var a = new CsvParser();
			var col = a.Parse(@"C:\Users\Sean\Downloads\FileNameFromFer.csv");

			CollectionAssert.AllItemsAreNotNull(col);
			Assert.IsTrue(col.Any(), "No items found");
		}
	}
}
