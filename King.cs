using System.Collections.Generic;

namespace Chess
{
    public class King : Figure //король
    {
        public bool IsMoved { get; private set; }
        public King(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
            IsMoved = false;
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var ret = new List<Position>
            {
                new Position(Pos.A - 1, Pos.B - 1),
                new Position(Pos.A - 1, Pos.B),
                new Position(Pos.A - 1, Pos.B + 1),

                new Position(Pos.A, Pos.B - 1),
                new Position(Pos.A, Pos.B + 1),

                new Position(Pos.A + 1, Pos.B - 1),
                new Position(Pos.A + 1, Pos.B),
                new Position(Pos.A + 1, Pos.B + 1)
            };
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