using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwilightImperium4Pregame
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string RaceGroup { get; set; }
    }

    public class Races
    {
        public List<Race> RaceList { get; set; }
    }
}
