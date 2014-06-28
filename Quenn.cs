using System.Collections.Generic;

namespace Chess
{
    public class Quenn : Figure //ферзь
    {
        public Quenn(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var l1 = new Bishop(Pos.A, Pos.B).AvailiblePositions;
            var l2 = new Rook(Pos.A, Pos.B).AvailiblePositions;
            l1.AddRange(l2);
            return l1;
        }
    }
}