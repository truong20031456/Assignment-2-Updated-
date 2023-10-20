using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyfirstProject
{
    internal class Dice

    {
        public int sides { set; get; }
        public string Type { set; get; }


        public Dice()
        {
             sides = 0;
            Type = "unknow";

        }
        public Dice(int sides, string type)
        {
            this.sides = sides;
            Type = type;
        }
        Random rm = new Random();
        public int Roll() { return rm.Next(1, sides +1); }
      
    }
}
