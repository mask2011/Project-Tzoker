using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tzoker
{
    class Results
    {
        public static void CompareLists(List<User> users, List<int> drawList)
        {
            var results = new List<List<int>>();
            foreach (User user in users)
            {
                int counter = 0;

                foreach (int x in drawList.Intersect(user.NumberList))
                {
                    counter += 1;
                }

                user.MatchingNumbersFound = counter;
            }
        }

        public static void CompareJokers(List<User> users, Draw drawPlayer)
        {
            foreach (User user in users)
            {
                if (user.JokerNumber == drawPlayer.JokerNumber)
                {
                    user.JokerMatch = true;
                }
                else
                {
                    user.JokerMatch = false;
                }
            }
        }

        public static void PrintResults(List<User> users)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Results:");
            //foreach (User user in users)
            //{
            //    Console.WriteLine($"Player{user.UserID} got {user.MatchingNumbersFound}+{user.JokerMatch} matches.");
                
            //}

            int winner = users.Where(u => u.MatchingNumbersFound == 5 && u.JokerMatch == true).Count();
            int fiveMatches = users.Where(u => u.MatchingNumbersFound == 5 && u.JokerMatch == false).Count();
            int fourPlusOneMatches = users.Where(u => u.MatchingNumbersFound == 4 && u.JokerMatch == true).Count();
            int fourMatches = users.Where(u => u.MatchingNumbersFound == 4 && u.JokerMatch == false).Count();
            int threePlusOneMatches = users.Where(u => u.MatchingNumbersFound == 3 && u.JokerMatch == true).Count();
            int threeMatches = users.Where(u => u.MatchingNumbersFound == 3 && u.JokerMatch == false).Count();
            int twoPlusOneMatches = users.Where(u => u.MatchingNumbersFound == 2 && u.JokerMatch == true).Count();
            int twoMatches = users.Where(u => u.MatchingNumbersFound == 2 && u.JokerMatch == false).Count();
            string results = $"5+1:{winner}\n5:  {fiveMatches}\n4+1:{fourPlusOneMatches}\n4:  {fourMatches}\n3+1:{threePlusOneMatches}\n3:  {threeMatches}\n2+1:{twoPlusOneMatches}\n2:  {twoMatches}";
            //results = results.Replace(",", System.Environment.NewLine);
            Console.WriteLine(results);

            if (users.Exists(u => u.MatchingNumbersFound == 5 && u.JokerMatch == true))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("We have a winner!!!");
                int player = (users.Where(u => u.MatchingNumbersFound == 5 && u.JokerMatch == true).Select(u => u.UserID).First());
                Console.WriteLine($"The winner is Player{player}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Jackpot!!!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        
        
    }
}
