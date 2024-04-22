using System;

namespace Zadania
{
    public class Kata
    {       
        public static bool Validate_hello(string greetings)
        {
            string[] greetingsList = { "hello", "ciao", "salut", "hallo", "hola", "ahoj", "cześć" };

            foreach (string greeting in greetingsList)
            {
                if (greetings.ToLower().Contains(greeting))
                {
                    Console.WriteLine("Rozpoznano język");
                    return true;
                }
            }
            Console.WriteLine("Niezidentyfikowany język");
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Wpisz wiadomość:");
            string message = Console.ReadLine();
            Validate_hello(message);
        }
    }
}
