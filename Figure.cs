using System;
using System.Collections.Generic;

namespace Chess
{
    internal abstract class Figure
    {
        public delegate void OnMove(Figure figure, Position oldPosition);

        public event OnMove HasMoved;

        public Position Pos { get; protected set; }

        protected Figure(int a, int b, bool isBlackColored=false)
        {
            if ((Math.Min(a, b) < 1) | (Math.Max(a, b) > 8))
                throw new ArgumentOutOfRangeException();
            
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

        public bool Move(Position newPosition)
        {
            return Move(newPosition.A, newPosition.B);
        }
    }
}
