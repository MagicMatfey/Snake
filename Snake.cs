namespace Snake
{
    public class Snake
    {
        public List<Point> Body { get; set; }
        public Directions Direction { get; set; }
        public ConsoleColor SnakeCollor = ConsoleColor.Red;
        public ConsoleColor HeadCollor = ConsoleColor.DarkRed;


        public Snake(Point point, Directions direction)
        {
            Direction = direction;
            Body = new List<Point>
            {
                point
            };
        }

        public void Move()
        {
            Point head = GetNextHeadPosition();
            Field.PrintCell(head, HeadCollor);
            Field.PrintCell(Body[0], SnakeCollor);
            Field.ClearCell(Body.Last());
            Body.Insert(0, head);
            Field.ClearCell(Body[Body.Count - 1]);
            Body.RemoveAt(Body.Count - 1);
        }

        public void Print()
        {
            Body.ForEach(point => Field.PrintCell(point, SnakeCollor));
            Field.PrintCell(Body[0], HeadCollor);
        }
        
        public void Eat()
        {
            Point head = GetNextHeadPosition();
            Field.PrintCell(head, HeadCollor);
            Field.PrintCell(Body[0], SnakeCollor);
            Body.Insert(0, head);
        }

        public Point GetNextHeadPosition()
        {
            var head = Body[0];
            
            switch (Direction)
            {
                case Directions.Left:
                    return new Point(head.X - 1, head.Y);

                case Directions.Right:
                    return new Point(head.X + 1, head.Y);

                case Directions.Up:
                    return new Point(head.X, head.Y - 1);

                case Directions.Down:
                    return new Point(head.X, head.Y + 1);

                default:
                    return new Point(head);
            }
        }
    }
}