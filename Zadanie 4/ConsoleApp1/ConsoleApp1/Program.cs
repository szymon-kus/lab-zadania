using System;

public class LandPerimeter
{
    public static string Calculate(string[] map)
    {
        int rows = map.Length;
        int cols = map[0].Length;
        int totalPerimeter = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (map[i][j] == 'X')
                {
                    int perimeter = 4;

                    if (i > 0 && map[i - 1][j] == 'X')
                        perimeter -= 2;
                    if (j > 0 && map[i][j - 1] == 'X')
                        perimeter -= 2;

                    totalPerimeter += perimeter;
                }
                else if (map[i][j] == '0')
                {
                }
                else
                {
                    throw new ArgumentException("Nieprawidłowy znak w mapie.");
                }
            }
        }

        return $"Total land perimeter: {totalPerimeter}";
    }

    public static void Main(string[] args)
    {
        string[] map = {
            "X00X0",
            "X00X0",
            "000X0",
            "XX0X0",
            "0X000"
        };

        string result = Calculate(map);
        Console.WriteLine(result);
    }
}
