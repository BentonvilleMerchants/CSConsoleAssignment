using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSConsoleAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Variables
            int iNumTeams;
            int iCount = 0;
            string sTeamName; //NEED TO ASK: Should this variable go down in the while loop?
            int iTeamPoints;


            Console.WriteLine("How many teams are in the tournament?");
            string sUserInput = Console.ReadLine();

            iNumTeams = ReadInt(sUserInput);

            List<SoccerTeam> stTeams = new List<SoccerTeam>();
            //iNumTeams = 3;
            while(iCount < iNumTeams)
            {
                
                Console.WriteLine("\nEnter Team " + (iCount + 1) + "'s Name:");
                //Console.ReadLine();
                sTeamName = UppercaseFirst(Console.ReadLine());

                Console.WriteLine("\nEnter " + sTeamName + "'s points:");
                sUserInput = Console.ReadLine();

                iTeamPoints = ReadInt(sUserInput);


                SoccerTeam stNewTeam = new SoccerTeam(sTeamName,iTeamPoints);
                stTeams.Add(stNewTeam);

                iCount= iCount + 1;
            }


        }

        static int ReadInt(string sUserInput)
        {
            int iNum;
            bool bCheck = true;

            while(bCheck)
            {


                if (int.TryParse(sUserInput, out iNum)) // Try to parse the string as an integer
                {
                    
                    bCheck = false; 
                }
                else
                {
                    Console.WriteLine("Please enter a valid number:");
                    sUserInput = Console.ReadLine();
                }
            }

            
                
            return iNum = int.Parse(sUserInput);
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }

    class Team
    {
        public string name;
        public int wins;
        public int loss;
    }

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

    class Game
    {

    }
}
