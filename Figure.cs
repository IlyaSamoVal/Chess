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
        }

        public Position Pos { get; protected set; }
        public List<Position> AvailiblePositions { get; protected set; }

        protected Figure(int a, int b, bool isBlackColored=false)
        {
            if ((Math.Min(a, b) < 1) | (Math.Max(a, b) > 8))
                throw new ArgumentException();
            
            Pos=new Position(a,b);
            IsBlackColored = isBlackColored;
            AvailiblePositions = GetAvailiblePositions();
        }

        public bool IsBlackColored { get; protected set; }
        protected abstract List<Position> GetAvailiblePositions();
        public virtual bool Move(int newA, int newB)
        {
            if (!AvailiblePositions.Exists(p => p.A == newA & p.B == newB)) return false;
            var retPos = Pos;
            Pos=new Position(newA,newB);
            AvailiblePositions = GetAvailiblePositions();
            HasMoved(this, retPos);
            return true;
        }

        public void DeleteAvailiblePosition(int a, int b)
        {
            AvailiblePositions.RemoveAll(p => p.A == a & p.B == b);
        }
        public override string ToString()
        {
            return string.Format("{3} {0} {2}{1}", GetType().ToString().Split('.')[1].ToLower(), (char)(Pos.A+'a'-1), Pos.B, IsBlackColored?"Black":"White");
        }

    }
}
