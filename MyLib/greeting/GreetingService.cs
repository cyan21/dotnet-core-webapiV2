using System;

namespace Greeting
{
    public class Greetings
    {
        public string sp()
        {
            return "Hola";
        }

        public string fr()
        {
            return "Bonjour";
        }

        public string jp()
        {
            return "Konnichiwa";
        }

        public string de()
        {
            return "Guten Tag";
        }

        public static void Main()
        {
            Greetings g = new Greetings();
            //Console.WriteLine($"Miguel says {g.sp()}");
            Console.WriteLine("Miguel says {0}", g.sp());
            
            //Console.WriteLine($"Pierre says {g.fr()}");
            Console.WriteLine("Pierre says {0}", g.fr());
            
            //Console.WriteLine($"Pierre says {g.jp()}");
            Console.WriteLine("Taro says {0}", g.jp());
        }
    }
}
