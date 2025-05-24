using System.Drawing;

namespace Snake
{
    public class Field
    {
        public const int Width = 10;
        public const int Height = 10;
        public const int topOffset = 2;
        private static ConsoleColor _fueldCollor = ConsoleColor.Gray;

        public static void PrintBackGround()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = topOffset;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.BackgroundColor = _fueldCollor;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write(" ");
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public static void PrintCell(Point point, ConsoleColor color)
        {
            Console.CursorLeft = point.X * 3;
            Console.CursorTop = point.Y + topOffset;
            
            Console.BackgroundColor = color;
            Console.Write("  ");
            Console.ResetColor();
            Console.Write(" ");

            Console.CursorTop = Height;
            Console.CursorLeft = 0;
        }

        public static void ClearCell(Point point)
        {
            PrintCell(point, _fueldCollor);
        }
    }
}