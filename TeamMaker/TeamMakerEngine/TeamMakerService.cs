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
        private int _teamSize;

        public TeamMakerService(IParser parser,int teamSize)
        {
            _parser = parser;
            _teamSize = teamSize;
        }

        public string Process(string inputFilePath)
        {
            var players = _parser.Parse(inputFilePath);

            return players.Count.ToString();
        }

       
    }


}
