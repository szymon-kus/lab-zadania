using System;

namespace zadanie3
{
    public class Program
    {
        public string MazeRunner(int[,] maze)
        {
            int[] start = FindStart(maze);
            int x = start[0];
            int y = start[1];

            ConsoleKeyInfo key;

            do
            {
                PrintMaze(maze, x, y);

                Console.WriteLine("Naciśnij strzałkę (↑, ↓, ←, →) lub Escape (Esc) aby zakończyć:");

                key = Console.ReadKey(true);

                int newX = x;
                int newY = y;

                // Oblicz nową pozycję gracza na podstawie wciśniętego klawisza
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        newX = x - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        newX = x + 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        newY = y - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        newY = y + 1;
                        break;
                    case ConsoleKey.Escape:
                        return "quit";
                }

                // Sprawdź czy nowa pozycja gracza jest poprawna
                if (newX >= 0 && newX < maze.GetLength(0) && newY >= 0 && newY < maze.GetLength(1) && maze[newX, newY] != 1)
                {
                    x = newX;
                    y = newY;
                }
                else
                {
                    // Jeśli uderzymy w ścianę, kończymy grę
                    return "dead";
                }

                if (maze[x, y] == 3)
                    return "finish";

            } while (key.Key != ConsoleKey.Escape);

            return "lost";
        }

        private int[] FindStart(int[,] maze)
        {
            int[] start = new int[2];

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == 2)
                    {
                        start[0] = i;
                        start[1] = j;
                        return start;
                    }
                }
            }

            return start;
        }

        private void PrintMaze(int[,] maze, int playerX, int playerY)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (i == playerX && j == playerY)
                    {
                        Console.Write("P "); // Gracz
                    }
                    else
                    {
                        switch (maze[i, j])
                        {
                            case 0:
                                Console.Write(". "); // Korytarz
                                break;
                            case 1:
                                Console.Write("# "); // Ściana
                                break;
                            case 2:
                                Console.Write("S "); // Start
                                break;
                            case 3:
                                Console.Write("F "); // Koniec
                                break;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            int[,] maze = GenerateMaze();

            string result = program.MazeRunner(maze);

            if (result == "quit")
                Console.WriteLine("Zakończono grę.");
            else if (result == "dead")
                Console.WriteLine("Śmierć! Koniec gry.");
            else
                Console.WriteLine("Koniec gry: " + result);
        }

        private static int[,] GenerateMaze()
        {
            // Wielkość labiryntu
            int rows = 7;
            int columns = 7;
            int[,] maze = new int[rows, columns];

            maze[0, 0] = 2; // Start
            maze[1, 6] = 3; // Koniec

            maze[1, 1] = 1;
            maze[1, 2] = 1;
            maze[1, 3] = 1;
            maze[1, 4] = 1;
            maze[1, 5] = 1;
            maze[2, 1] = 1;
            maze[2, 3] = 1;
            maze[2, 5] = 1;
            maze[3, 3] = 1;
            maze[4, 1] = 1;
            maze[4, 3] = 1;
            maze[4, 5] = 1;
            maze[5, 1] = 1;
            maze[5, 5] = 1;
            maze[6, 1] = 1;
            maze[6, 3] = 1;
            maze[6, 5] = 1;

            return maze;
        }
    }
}
