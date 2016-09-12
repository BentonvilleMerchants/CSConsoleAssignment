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
            string sTeamName;
            int iTeamPoints;

            List<SoccerTeam> stTeams = new List<SoccerTeam>();

            Console.Write("How many teams are in the tournament? ");
            iNumTeams = Convert.ToInt32(Console.ReadLine());


            while (iCount < iNumTeams)
                {
                    try
                    {
                        Console.Write("\nEnter Team " + (iCount + 1) + "'s Name: ");
                        sTeamName = UppercaseFirst(Console.ReadLine());

                        Console.Write("Enter " + sTeamName + "'s points: ");
                        iTeamPoints = Convert.ToInt32(Console.ReadLine());

                        SoccerTeam stNewTeam = new SoccerTeam(sTeamName, iTeamPoints);
                        stTeams.Add(stNewTeam);
                        iCount++;
                    }

                    catch(Exception e)
                    {
                        Console.WriteLine("\nPlease enter a number.");
                    }

                }


            List<SoccerTeam> sortedTeams = stTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();

            Console.WriteLine("\n\nHere is the sorted list:");

            Console.WriteLine("\nPosition           Name                       Points");
            Console.Write("--------           ----                       ------");

            iCount = 1;

            foreach (SoccerTeam st in sortedTeams)
            {
                Console.Write("\n" + Convert.ToString(iCount).PadRight(19, ' '));
                Console.Write(Convert.ToString(st.name).PadRight(27, ' '));
                Console.Write(Convert.ToString(st.points));

                iCount++;
            }

            Console.ReadLine();
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

        static int CheckInt(string sUserInput)
        {


            return;
        }
    }

}
