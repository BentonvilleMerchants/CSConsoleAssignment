using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


// ------------------------------------------------------------------------------
// Author: Joseph Isabell
// Create Date: 9/12/2016
// Description: Console program written for an assignment in IS 403 at BYU. 
// The program takes input from users to simulate a very basic soccer
// tournament. 
// ------------------------------------------------------------------------------


namespace CSConsoleAssignment
{
    class Program
    {
        static void Main(string[] args)
        {

            bool bPlayAgain = true;

            while (bPlayAgain)
            {

                // Declare Variables
                int iNumTeams;
                int iCount = 0;

                // Create a new list of SoccerTeam objects
                List<SoccerTeam> stTeams = new List<SoccerTeam>();

                // Prompt the user to enter the number of teams to be included in the
                // tournament simulation.
                iNumTeams = RequestIntFromUser("How many teams?");

                // Ask the user to enter the team's name and points to create a new
                // soccer team object. Program exits the loop when the number of teams has 
                // reached the number indicated eariler by the user (iNumTeams)
                while (iCount < iNumTeams)
                {
                    // Variables
                    string sTeamName;
                    int iTeamPoints;

                    // Prompt the user to input the team name
                    Console.Write("\n\nEnter Team " + (iCount + 1) + "'s Name: ");
                    sTeamName = UppercaseFirst(Console.ReadLine());

                    Console.WriteLine();

                    // Prompt the user to input the team's points
                    iTeamPoints = RequestIntFromUser("Enter " + sTeamName + "'s points:");

                    // Create new SoccerTeam object and add it to the List created previously
                    SoccerTeam stNewTeam = new SoccerTeam(sTeamName, iTeamPoints);
                    stTeams.Add(stNewTeam);
                    iCount++;
                }


                // Sort the teams by their points in descending order 
                List<SoccerTeam> sortedTeams = stTeams.OrderByDescending(SoccerTeam => SoccerTeam.points).ToList();

                // Write tournament results table header to the console
                Console.WriteLine("\n\nHere is the sorted list:");
                Console.WriteLine("\nPosition           Name                       Points");
                Console.Write("--------           ----                       ------");

                // iCount is reset to 1 so that it can be used as the Position number
                // in the next foreach loop
                iCount = 1;

                // Write tournament results to the console
                foreach (SoccerTeam st in sortedTeams)
                {
                    Console.Write("\n" + Convert.ToString(iCount).PadRight(19, ' '));
                    Console.Write(Convert.ToString(st.name).PadRight(27, ' '));
                    Console.Write(Convert.ToString(st.points));
                    iCount++;
                }

                // Program waits 1 second before asking the user if they want to play again
                Console.CursorVisible = false;
                Thread.Sleep(1000);
                Console.CursorVisible = true;

                Console.Write("\n\n\nWould you like to play again? (Y/N) ");
                string s = Console.ReadLine().ToUpper();

                // Evaluate response from user
                if (s.Contains("Y"))
                {
                    // Remove play again question and add a line to seperate the 1st game from the second
                    Console.CursorTop--;
                    Console.Write("                                                                         ");
                    Console.CursorLeft = 0;
                    Console.WriteLine("-------------------------------------------------------------------\n\n");
                }
                else
                {
                    bPlayAgain = false;
                }

            }

            Console.WriteLine("\n\n\nThanks for playing!");
            Thread.Sleep(1000);
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

        
        // Method used to ask the user to input an integer and then check the input to make
        // sure it is an integer and is greater than 0. The method has one string parameter
        // that is used to pass the specific question that should be written to the console
        // when prompting the user to input an integer.
        static int RequestIntFromUser(string sQuestion)
        {
            // Declare variables
            bool bCheck = true;
            int iNum;
            int iCount = 0;
            string sUserInput;

            // Prompt the user to enter an int using the question parameter
            Console.Write(sQuestion + " ");
            sUserInput = Console.ReadLine();

            // Program stays in the while loop until a valid integer greater than 0 is inputed
            // by the user.
            while (bCheck)
            {
                // Checks to see if the input from the user is an integer or not
                if (int.TryParse(sUserInput, out iNum))
                {
                    // Checks to see if the integer is greater than zero
                    if (iNum > 0)
                    {
                        // When the user inputs a valid integer the invalid entries are erased
                        // and the valid integer is displayed next to the original question
                        bCheck = false;

                        while(iCount >= 0)
                        {
                            Console.CursorTop--;
                            Console.Write("                                                                    ");
                            Console.CursorLeft = 0;
                            iCount--;
                        }

                        Console.WriteLine(sQuestion + " " + sUserInput);
                    }
                    else
                    {
                        // If the user input is an integer but not greater than 0 then the user 
                        // is prompted to enter a different number
                        Console.Write("   Please enter a number greater than 0: ");
                        sUserInput = Console.ReadLine();
                        iCount++;
                    }
                }
                else
                {
                    // If the user input is not an integer the user is prompted to enter a 
                    // valid number.
                    Console.Write("   Please enter a valid number: ");
                    sUserInput = Console.ReadLine();
                    iCount++;
                }
            }

            return iNum = Convert.ToInt32(sUserInput);
        }
    }

}
