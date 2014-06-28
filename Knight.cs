using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Knight : Figure //конь
    {
        public Knight(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
        }

        internal override List<Position> GetAvailiblePositions(List<Figure> list)
        {
            var ret = new List<Position>();
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 1, Pos.B - 2) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 1, Pos.B - 2));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 1, Pos.B + 2) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 1, Pos.B + 2));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 1, Pos.B + 2) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 1, Pos.B + 2));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 1, Pos.B - 2) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 1, Pos.B - 2));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 2, Pos.B + 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 2, Pos.B + 1));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A + 2, Pos.B - 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A + 2, Pos.B - 1));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 2, Pos.B + 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 2, Pos.B + 1));
            ////
            if (!(list.Exists(f => f.Pos == new Position(Pos.A - 2, Pos.B - 1) & (f.IsBlackColored ^ IsBlackColored))))
                ret.Add(new Position(Pos.A - 2, Pos.B - 1));
            ////
            var tret = new List<Position>(ret.Where(p => (p.A >= 1 & p.A <= 8) & (p.B >= 1 & p.B <= 8)));
            return tret;
        }
    }
}