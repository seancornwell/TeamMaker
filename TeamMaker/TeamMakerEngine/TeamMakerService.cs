using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMakerEngine
{
    public class TeamMakerService
    {

        private IParser _parser;

        public TeamMakerService(IParser parser)
        {
            _parser = parser;
        }

        public string Process(string inputFilePath)
        {
            var players = _parser.Parse(inputFilePath);

            return players.Count.ToString();
        }

   
    }


}
