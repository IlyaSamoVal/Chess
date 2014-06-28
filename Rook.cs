using System.Collections.Generic;

namespace Chess
{
    public class Rook : Figure //ладья
    {

        public bool IsMoved { get; private set; }

        public Rook(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
            IsMoved = false;
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var ret = new List<Position>();
            for (var i = 1; i <= 8; i++)
            {
                if (i != Pos.A) ret.Add(new Position(Pos.A, i));
                if (i != Pos.B) ret.Add(new Position(i, Pos.B));
            }
            return ret;
        }

        public override bool Move(int newA, int newB)
        {
            var b = base.Move(newA, newB);
            if (b & !IsMoved) IsMoved = true;
            return b;
        }
    }
}