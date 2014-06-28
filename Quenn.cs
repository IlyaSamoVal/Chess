using System.Collections.Generic;

namespace Chess
{
    public class Quenn : Figure //ферзь
    {
        public Quenn(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
        }

        internal override List<Position> GetAvailiblePositions(List<Figure> list)
        {
            var l1 = new Bishop(Pos.A, Pos.B).GetAvailiblePositions(list);
            var l2 = new Rook(Pos.A, Pos.B).GetAvailiblePositions(list);
            l1.AddRange(l2);
            return l1;
        }
    }
}