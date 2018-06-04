using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tzoker
{
    class Game
    {
        public List<int> NumberList { get; set; }
        public int JokerNumber { get; set; }

        public static void RunGame()
        {
            Console.WriteLine("Welcome to the Joker Game");
            Console.WriteLine("");
            List<User> users = User.PopulatePlayers();
            Draw drawPlayer = Draw.GetDrawPlayer();
            Results.CompareLists(users, drawPlayer.NumberList);
            Results.CompareJokers(users, drawPlayer);
            Results.PrintResults(users);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


    }
}
