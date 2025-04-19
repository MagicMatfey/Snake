using System;
namespace Snake
{
	public class Food
	{
		public Point Position { get; set; }
		public Food()
		{
			Position = new Point(-1, -1);
        }


		public void RndGeneration(int uplen, int shirlen)
		{
			Random rnd = new Random();
			Position.X = rnd.Next(shirlen);
            Position.Y = rnd.Next(uplen);
        }
    }
}

	