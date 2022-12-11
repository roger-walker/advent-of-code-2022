namespace AdventOfCode2022
{
    public class Location : IEquatable<Location>

    {
        public int X;
        public int Y;

        public Location()
        {
            X = 0;
            Y = 0;
        }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        bool IEquatable<Location>.Equals(Location? other)
        {
            if (other == null) return false;
            return X == other.X && Y == other.Y;
        }


        public override string ToString()
        {
            return $"x:{X} y:{Y}";
        }


    }

    public class LocationEqualityComparer : IEqualityComparer<Location>
    {

        bool IEqualityComparer<Location>.Equals(Location? one, Location? two)
        {
            if ((one == null || two == null)) return false;

            return one.X == two.X && one.Y == two.Y;
        }

        int IEqualityComparer<Location>.GetHashCode(Location loc)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(loc.ToString());
        }

    }


    public enum Direction
    {
        Unknown,
        Up,
        Down,
        Left,
        Right
    }

    public class Day9
    {


        public Location Head { get; set; } = new Location();
        public Location Tail { get; set; } = new Location();

        public HashSet<Location> TailLocations { get; set; } = new HashSet<Location>(new LocationEqualityComparer());

        public Day9()
        {
            TailLocations.Add(new Location(0,0));
        }

        public int GetTailPositions()
        {
            return TailLocations.Count;
        }

        public bool IsAdjacent()
        {
            return Math.Abs(Head.X - Tail.X) <= 1 && Math.Abs(Head.Y - Tail.Y) <= 1;
        }

        public void RunInstructions(List<string> instr)
        {
            foreach (var inst in instr)
            {
                MoveHead(inst);
            }
        }

        public List<Location> MoveHead(string instr)
        {
            List<Location> headMoves = new List<Location>();
            (Direction dir, int dist) = GetDirectionDistance(instr);
            for (int i = 0; i < dist; i++)
            {
                Head = Move(Head, dir);
                if (!IsAdjacent())
                {
                    Location tail = MoveTail();
                    TailLocations.Add(tail);
                }
                headMoves.Add(Head);
            }

            return headMoves;
        }

        public Location Move(Location loc, Direction dir)
        {
            Location next = new Location(loc.X, loc.Y);
            switch (dir)
            {
                case Direction.Up:
                    next = new Location(loc.X, loc.Y + 1);
                    break;
                case Direction.Down:
                    next = new Location(loc.X, loc.Y - 1);
                    break;
                case Direction.Left:
                    next = new Location(loc.X - 1, loc.Y);
                    break;
                case Direction.Right:
                    next = new Location(loc.X + 1, loc.Y);
                    break;
            }

            return next;
        }

        public (Direction, int) GetDirectionDistance(string instr)
        {
            var pieces = instr.Split(' ');

            Direction dir = Direction.Unknown;
            switch (pieces[0])
            {
                case "U":
                    dir = Direction.Up;
                    break;
                case "D":
                    dir = Direction.Down;
                    break;
                case "L":
                    dir = Direction.Left;
                    break;
                case "R":
                    dir = Direction.Right;
                    break;
            }

            int dist = Convert.ToInt32(pieces[1]);

            return (dir, dist);
        }

        public Location MoveTail()
        {
            if (Head.X != Tail.X && Head.Y == Tail.Y)
            {
                int adj = Head.X - Tail.X;
                Tail.X = adj > 0 ? Tail.X + 1 : Tail.X - 1;
            }
            else if (Head.Y != Tail.Y && Head.X == Tail.X)
            {
                int adj = Head.Y - Tail.Y;
                Tail.Y = adj > 0 ? Tail.Y + 1 : Tail.Y - 1;
            }
            else
            {
                int adjx = Head.X - Tail.X;
                int adjy = Head.Y - Tail.Y;
                Tail.X = adjx > 0 ? Tail.X + 1 : Tail.X - 1;
                Tail.Y = adjy > 0 ? Tail.Y + 1 : Tail.Y - 1;
            }

            if (!IsAdjacent())
            {
                throw new Exception("No idea where to move!");
            }

            return new Location(Tail.X, Tail.Y);
        }
    }
}
