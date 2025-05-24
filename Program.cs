using System.Drawing;

namespace Snake;

class Program
{
    public static int maxpoints = 0;
    public static bool isNewRecord = false;
    public static int _speed = 1;
    private static int _speedStep = 25;
    private static string _path = "table_of_leader.txt";
    private static Food _food;
    private static Snake _snake;
    private static int _counter = 0;
    private static bool _isGameRunning = true;

    static void Main(string[] args)
    {
        try
        {
            using (StreamReader reader = new StreamReader(_path))
            {
                maxpoints = Convert.ToInt32(reader.ReadLine());
            }
        }
        catch (Exception)
        {
            maxpoints = 0;
        }
        Field.PrintBackGround();
        _snake = new Snake(new Point(Field.Height / 4, Field.Width / 2), Directions.Right);
        _snake.Print();
        _food = new Food();
        FoodGeneration();
        Action();
    }
    
    public static void Action()
    {
        do
        {
 
            Thread.Sleep(Math.Max(800 - _speed * _speedStep, 175));
            HandleInput();
            Update();
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.WriteLine("Количество очков: " + _counter);
        } while (_isGameRunning);
    }
    
    private static void Update()
    {
        Point next = _snake.GetNextHeadPosition();
        
        if (CheckCollision(next))
        {
            _isGameRunning = false;
            if (maxpoints < _counter)
            {
                using (StreamWriter writer = new StreamWriter(_path, false))
                {
                    writer.WriteLineAsync(Convert.ToString(_counter));
                }
            }
            return;
        }
        
        if (next.Equals(_food.Position))
        {
            _counter += _food.Fruit.Price;
            _snake.Eat();
            FoodGeneration();
            _speed++;

            if (maxpoints < _counter && isNewRecord == false)
            {
                isNewRecord = true;
                Console.CursorLeft = 0;
                Console.CursorTop = 1;
                Console.WriteLine("Вы побили свой рекорд!!!");
            }

        }
        else
        {
            _snake.Move();
            foreach (var i in _snake.Body)
            {
                Field.PrintCell(i, _snake.SnakeCollor);
            }
            Field.PrintCell(_snake.Body[0], _snake.HeadCollor);
        }
    }

    private static void HandleInput()
    {
        if (!Console.KeyAvailable) return;

        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.W && _snake.Direction != Directions.Down)
        {
            _snake.Direction = Directions.Up;
        }
        else if (key == ConsoleKey.S && _snake.Direction != Directions.Up)
        {
            _snake.Direction = Directions.Down;
        }
        else if (key == ConsoleKey.A && _snake.Direction != Directions.Right)
        {
            _snake.Direction = Directions.Left;
        }
        else if (key == ConsoleKey.D && _snake.Direction != Directions.Left)
        {
            _snake.Direction = Directions.Right;
        }
    }

    public static void FoodGeneration()
    {
        do
        {
            _food.RndGeneration();

        } while (_snake.Body.Contains(_food.Position));
        _food.Print();
    }
    
    public static bool CheckCollision(Point head)
    {
        if (head.X < 0 || head.X >= Field.Width || head.Y < 0 || head.Y >= Field.Height)
        {
            return true;
        }

        return _snake.Body.Contains(head);
    }
}

public enum Directions
{
    Up,
    Down,
    Left,
    Right
}