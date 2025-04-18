using System;
namespace Snake
{
	public class Snake
	{
		public List<Point> Body { get; set; }
        public Direction Directeon { get; set; }

		public Snake(Point point, Direction direction)
		{
            Directeon = direction;
            Body = new List<Point> {point};
		}

        public void Move(FueldType[,] Fueld)
        {
            Fueld[Body[0].X, Body[0].Y] = FueldType.Null;
            Body.Insert(0, GetNextPosition());
            Fueld[Body[0].X, Body[0].Y] = FueldType.Snake;
        }

        public Point GetNextPosition()
        {
            switch (Directeon)
            {
                case Direction.Left:
                    return new Point(Body[0].X, Body[0].Y-1);

                case Direction.Right:
                    return new Point(Body[0].X, Body[0].Y+1);

                case Direction.Up:
                    return new Point(Body[0].X-1, Body[0].Y);

                case Direction.Down:
                    return new Point(Body[0].X+1, Body[0].Y);

                default:
                    return new Point(Body[0].X, Body[0].Y);
            }
        }


        public bool ChekColision(int wight, int len)
        {
            if (Body[0].X == 10)
            {
                return true;
            }
            return true;
        }

    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}

