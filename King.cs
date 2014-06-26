using System.Collections.Generic;

namespace Chess
{
    public class King : Figure //король
    {
        private bool _isMoved;
        public King(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {
            _isMoved = false;
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
            if (b & !_isMoved) _isMoved = true;
            return b;
        }
    }
}