namespace Snake
{
    public class Food
    {
        public Point Position { get; set; }
        public Fruit Fruit { get; set; }

        private List<Fruit> _fruits = new List<Fruit>
        {
            new Fruit("Яблоко", ConsoleColor.Yellow, 300),
            new Fruit("Черника", ConsoleColor.Cyan, 500),
            new Fruit("Драконий фрукт", ConsoleColor.Magenta, 800),

        };
        //public int Price { get; set; }

        //public static Dictionary<int, Food> RandomFruit = new Dictionary<int, Food>
        //{
        //    { 1, new Food(ConsoleColor.Cyan, 300) },
        //    { 2, new Food(ConsoleColor.DarkBlue, 600) },
        //    { 3, new Food(ConsoleColor.DarkYellow, 200) },
        //    { 4, new Food(ConsoleColor.DarkMagenta, 800) }
        //};

        public Food()
        {
            Position = new Point();
        }

        public void RndGeneration()
        {
            Random rnd = new Random();
            Fruit = _fruits.ElementAt(rnd.Next(_fruits.Count));
            Position.X = rnd.Next(Field.Width);
            Position.Y = rnd.Next(Field.Height);
        }

        public void Print()
        {
            Field.PrintCell(Position, Fruit.Color);
        }
    }
}