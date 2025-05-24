using System;
namespace Snake
{
	public class Fruit
	{
        public string Name { get; set; }

        public ConsoleColor Color { get; set; }

        public int Price { get; set; }

        public Fruit(string name, ConsoleColor color, int price)
        {
            Name = name;
            Color = color;
            Price = price;
        }
    }
}
