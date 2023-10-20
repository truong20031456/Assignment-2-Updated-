using System;
using System.Globalization;

namespace MyfirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string dateAsText = Console.ReadLine();*/
            /*DateTime birthday = new DateTime(2000, 2, 11);
            Console.WriteLine(birthday.Day.ToString());
            Console.WriteLine(birthday.Month.ToString());
            Console.WriteLine(birthday.Year);
            Console.WriteLine(birthday.Hour.ToString());
            Console.WriteLine(birthday.DayOfWeek);
            Console.WriteLine(birthday.Minute.ToString());
            Console.WriteLine(birthday.DayOfYear);*/
            /* DateTime date = DateTime.ParseExact( dateAsText, "yyyy-M-d" ,CultureInfo.InvariantCulture );
             Console.WriteLine( date.Day );
             Console.WriteLine( date.Hour );
             Console.WriteLine( date.Minute ); 
             Console.WriteLine( date.Second );
             Console.WriteLine( date.Millisecond );*/
            /* DateTime today = DateTime.Today;
              DateTime now = DateTime.Now;
              Console.WriteLine(today);
              Console.WriteLine(now);
              Console.WriteLine(now.AddDays(7));*/
            /*string[] words = Console.ReadLine().Split(' ');
            Random random = new Random();
            for (int post1 = 0; post1 < words.Length; post1++) {
                int post2 = random.Next(words.Length);
                string name = words[post1];
                words[post1] = words[post2];
                words[post2] = name;
                 
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));*/
          
         /* for( int i = 0;i < 50 ; i++ ) 
            {
                Random rnd = new Random();
                Console.WriteLine(rnd.Next(1,9));         
            }*/
         Dice newdice= new Dice();
            Console.WriteLine(newdice.sides);
            Console.WriteLine(newdice.Type);

            Dice newDice = new Dice(6,"hiua") ;
Console.WriteLine(newDice.sides);
            Console.WriteLine(newDice.Type);
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(newDice.Roll()+" ");

            }
            Console.WriteLine();
        }
    }
}