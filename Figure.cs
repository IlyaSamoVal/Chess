using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Figure
    {
        public struct Position
        {
            public int A;
            public int B;

            public Position(int a, int b)
            {
                A = a;
                B = b;
            }
        }

        protected Position Pos;
        public static int Max = 8;
        public List<Position> AvailiblePositions { get; protected set; }

        protected Figure(int a, int b, bool isBlackColored)
        {
            if ((Math.Min(a, b) < 1) | (Math.Max(a, b) > Max))
                throw new ArgumentException();
            
            Pos.A = a;
            Pos.B = b;
            IsBlackColored = isBlackColored;
            AvailiblePositions = GetAvailiblePositions();
        }

        public bool IsBlackColored { get; protected set; }
        protected abstract List<Position> GetAvailiblePositions();
        public virtual bool Move(int newA, int newB)
        {
            if (!AvailiblePositions.Exists(p => p.A == newA & p.B == newB)) return false;
            Pos.A = newA;
            Pos.B = newB;
            AvailiblePositions = GetAvailiblePositions();
            return true;
        }

        public void DeleteAvailiblePosition(int a, int b)
        {
            AvailiblePositions.RemoveAll(p => p.A == a & p.B == b);
        }
        public override string ToString()
        {
            return string.Format("{3} {0} {2}{1}", GetType().ToString().Split('.')[1].ToLower(), (char)(Pos.A+'a'), Pos.B, IsBlackColored?"Black":"White");
        }

    }
}
