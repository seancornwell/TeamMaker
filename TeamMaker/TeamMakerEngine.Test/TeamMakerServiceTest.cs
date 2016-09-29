using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMakerEngine.Test
{
    [TestClass]
    public class TeamMakerServiceTest
    {
        [TestMethod]
        public void ProcessTest()
        {
            var parser = new CsvParser();
            var service = new TeamMakerService(parser,12);
            
            var message = service.Process(@".\SampleFiles\SamplePlayers_Pre-1.csv");

            Assert.AreEqual("119", message);
        }
    }
}
