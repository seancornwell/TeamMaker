using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMakerEngine
{
    public interface IParser
    {
        List<Player> Parse(string filepath);
    }
}
