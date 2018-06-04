using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tzoker
{
    class User : Game, DrawNumbersAndJoker
    {
        public int UserID { get; set; }
        public int MatchingNumbersFound { get; set; }
        public bool JokerMatch { get; set; }

        public User(int i)
        {
            UserID = i;
        }

        public static int HowManyPlayers()
        {
            int numberOfPlayers = 0;
            do
            {
                try
                {
                    Console.Write("How many players will play? ");
                    numberOfPlayers = int.Parse(Console.ReadLine());

                    if (numberOfPlayers == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please input a number of Players.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please input a number of Players.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (numberOfPlayers == 0);
            
            
            return numberOfPlayers;
        }

        public static List<User> PopulatePlayers()
        {
            var users = new List<User>();
            int counter = HowManyPlayers();

            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"Player {i + 1}:");
                User player = new User(i + 1);
                GetUserNumbers(player);
                users.Add(player);
            }
            return users;
        }

        public static User GetUserNumbers(User player)
        {
            player.NumberList = player.BuildNumberList();
            player.JokerNumber = player.GetJoker();
            return player;
        }
        
        public List<int> BuildNumberList()
        {
            var userList = new List<int>(5);

                for (int i = 0; i < userList.Capacity; i++)
                {
                    int userNumber = RandomNumbers.RandomNumber();

                    while (userList.Contains(userNumber))
                    {
                        userNumber = RandomNumbers.RandomNumber();
                    }
                    userList.Add(userNumber);

                }
            PrintUserList(userList);
            return userList;  
        }

        public int GetJoker()
        {
            int userJoker = RandomNumbers.RandomJoker();
            Console.WriteLine($"The Joker is: {userJoker}");
            return userJoker;
        }

        public static void PrintUserList(List<int> userList)
        {
            userList.Sort();
            foreach (int x in userList)
            {
                Console.WriteLine($"Number = {x}");
            }
        }
    }
}
