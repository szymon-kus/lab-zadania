namespace Zadanie2
{
    public static class Program
    {
        public static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            try { 
                Console.WriteLine("Podaj liczbę do sprawdzenia wyniku silni: ");
                int yourNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Factorial(yourNum));
            } catch (FormatException) {
                Console.WriteLine("Nieprawidłowa wartość.");
            }
        }
    }

}
