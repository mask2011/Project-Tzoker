using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tzoker
{
    class RandomNumbers
    {
        public static int RandomNumber()
        {
            var randomNumber = new Random();
            int drawNumber = randomNumber.Next(1, 46);
            return drawNumber;
        }

        public static int RandomJoker()
        {
            var randomJoker = new Random();
            int drawJoker = randomJoker.Next(1, 21);
            return drawJoker;
        }
    }
}
