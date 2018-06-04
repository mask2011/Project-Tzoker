using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tzoker
{
    class Draw : Game, DrawNumbersAndJoker
    {
        public static Draw GetDrawPlayer()
        {
            Draw DrawPlayer = new Draw();
            Console.WriteLine(" ");
            Console.WriteLine("Draw's Numbers are:");
            DrawPlayer.NumberList = DrawPlayer.BuildNumberList();
            DrawPlayer.JokerNumber = DrawPlayer.GetJoker();
            return DrawPlayer;
        }
    
        public List<int> BuildNumberList()
        {
            var drawList = new List<int>(5);
            for (int i = 0; i < drawList.Capacity; i++)
            {
                int drawNumber = RandomNumbers.RandomNumber();

                while (drawList.Contains(drawNumber))
                {
                    drawNumber = RandomNumbers.RandomNumber();
                }
                drawList.Add(drawNumber);

            }
            PrintDrawList(drawList);

            return drawList;
        }
        
        public int GetJoker()
        {
            int drawJoker = RandomNumbers.RandomJoker();
            Console.WriteLine($"The Joker is: {drawJoker}");
            return drawJoker;
        }

        public static void PrintDrawList(List<int> drawList)
        {
            drawList.Sort();

            foreach (int x in drawList)
            {
                System.Threading.Thread.Sleep(1200);
                Console.WriteLine($"Number = {x}");
            }
        }
    }
}
