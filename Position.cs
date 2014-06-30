namespace Chess
{
    public struct Position
    {
        public readonly int A;
        public readonly int B;

        public Position(int a, int b)
        {
            A = a;
            B = b;
        }

        public bool Equals(Position other)
        {
            return A == other.A && B == other.B;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Position && Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (A*397) ^ B;
            }
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }
    }
}