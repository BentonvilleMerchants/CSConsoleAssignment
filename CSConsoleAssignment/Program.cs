using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Header ***********************************************************************
// Author: Joseph Isabell
// Create Date: 9/12/2016
// Description: Console program written for an assignment in IS 403 at BYU. 
// The program takes input from users to simulate a very basic soccer
// tournament. 
// 
// ******************************************************************************


namespace CSConsoleAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare Variables
            int iNumTeams;
            int iCount = 0;
            int iTeamPoints;
            string sTeamName;

            // Create a new list of SoccerTeam objects to be used 
            List<SoccerTeam> stTeams = new List<SoccerTeam>();

            // Prompt the user to enter the number of teams to be included in the
            // tournament simulation.
            iNumTeams = RequestIntFromUser("How many teams are in the tournament?");


            while (iCount < iNumTeams)
                {
                    Console.Write("\nEnter Team " + (iCount + 1) + "'s Name: ");
                    sTeamName = UppercaseFirst(Console.ReadLine());

                    iTeamPoints = RequestIntFromUser("Enter " + sTeamName + "'s points: ");

                    SoccerTeam stNewTeam = new SoccerTeam(sTeamName, iTeamPoints);
                    stTeams.Add(stNewTeam);
                    iCount++;

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


        static int RequestIntFromUser(string sQuestion)
        {
            bool bCheck = true;
            int iNum;
            string sUserInput;

            Console.Write(sQuestion + " ");
            sUserInput = Console.ReadLine();

            while (bCheck)
            {
                if (int.TryParse(sUserInput, out iNum))
                {
                    bCheck = false;
                }
                else
                {
                    Console.Write("Please enter a valid number: ");
                    sUserInput = Console.ReadLine();
                }
            }

            return iNum = Convert.ToInt32(sUserInput);
        }
    }

}
