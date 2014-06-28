using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class King : Figure //король
    {
        public bool IsMoved { get; private set; }
        public King(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
            IsMoved = false;
        }

        internal override List<Position> GetAvailiblePositions(List<Figure> list)
        {
            var ret = new List<Position>();
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 1, Pos.B - 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 1, Pos.B - 1));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 1, Pos.B) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 1, Pos.B));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 1, Pos.B+1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 1, Pos.B + 1));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A, Pos.B - 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A, Pos.B - 1));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A, Pos.B + 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A, Pos.B + 1));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 1, Pos.B - 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 1, Pos.B - 1));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 1, Pos.B) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 1, Pos.B));

            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 1, Pos.B + 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 1, Pos.B + 1));
            ////
            var tret = new List<Position>(ret.Where(p => (p.A >= 1 & p.A <= 8) & (p.B >= 1 & p.B <= 8)));
            return tret;
        }

        public override bool Move(int newA, int newB)
        {
            var b = base.Move(newA, newB);
            if (b & !IsMoved) IsMoved = true;
            return b;
        }
    }
}