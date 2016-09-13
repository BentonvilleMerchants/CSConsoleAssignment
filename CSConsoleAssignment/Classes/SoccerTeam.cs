using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleAssignment
{
    class SoccerTeam : Team
    {
        //SoccerTeam Class Attributes
        public int draw;
        public int goalsFor;
        public int goalsAgainst;
        public int differential;
        public int points;

        //Constructors
        public SoccerTeam()
        {

        }

        public SoccerTeam(string sTeamName, int iPoints)
        {
            this.name = sTeamName;
            this.points = iPoints;
        }


    }
}
