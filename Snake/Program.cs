using System.Timers;

namespace Snake;
class Program
{
    public static bool _isGameRunning = true;
    public static int _schetchik = 0;
    public const int _shirina = 10;
    public const int _visota = 10;
    public static FueldType[,] Fueld = new FueldType[_visota, _shirina];
    public static Food _food = new Food();
    public static Snake _snake = new Snake(new Point(_shirina/2,_visota/3), Direction.Right);

    static void Main(string[] args)
    {
        for (int i = 0; i < _visota; i++)
        {
            for (int j = 0; j < _shirina; j++)
            {
                Fueld[i, j] = FueldType.Null;
            }
        }
        Fueld[_snake.Body[0].X, _snake.Body[0].Y] = FueldType.Snake;
        FoodGeneration();
        Deistvie();
    }


    public static void Deistvie()
    {
        do
        {
            _snake.Move(Fueld);
            PrintFueld();
            Thread.Sleep(1000);
            Console.Clear();
        } while (_isGameRunning);


    }

    public static void PrintFueld()
    {
        int i = 0;
        foreach(FueldType kletca in Fueld)
        {
            switch( kletca)
            {
                case FueldType.Null:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case FueldType.Food:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case FueldType.Snake:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
            }
            Console.Write("  ");
            Console.ResetColor();
            Console.Write(" ");
            i++;
            if (i == _shirina)
            {
                i = 0;
                Console.WriteLine();
            }
        }
            
    }

    public static void FoodGeneration()
    {
        bool IsNull = false;
        do
        {
            _food.RndGeneration(_shirina,_visota);
            if (Fueld[_food.Position.Y, _food.Position.X] == FueldType.Null)
            {                        
                IsNull = true;       
                Fueld[_food.Position.Y, _food.Position.X] = FueldType.Food;
            }
        } while (IsNull == false);

    }
}


public enum FueldType
{
    Null,
    Food,
    Snake
}