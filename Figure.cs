using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Figure
    {
        public delegate void OnMove(Figure figure, Position oldPosition);

        public event OnMove HasMoved;

        public struct Position
        {
            public int A;
            public int B;

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

        public Position Pos { get; protected set; }

        protected Figure(int a, int b, bool isBlackColored=false)
        {
            if ((Math.Min(a, b) < 1) | (Math.Max(a, b) > 8))
                throw new ArgumentException();
            
            Pos=new Position(a,b);
            IsBlackColored = isBlackColored;
        }

        public bool IsBlackColored { get; protected set; }
        internal abstract List<Position> GetAvailiblePositions(List<Figure> list);
        public virtual bool Move(int newA, int newB)
        {
            var retPos = Pos;
            Pos=new Position(newA,newB);
            HasMoved(this, retPos);
            return true;
        }
        public override string ToString()
        {
            return string.Format("{3} {0} {2}{1}", GetType().ToString().Split('.')[1].ToLower(), (char)(Pos.A+'a'-1), Pos.B, IsBlackColored?"Black":"White");
        }

    }
}
