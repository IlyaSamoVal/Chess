using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Figure //слон
    {
        public Bishop(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
        }

        internal override List<Position> GetAvailiblePositions(List<Figure> list)
        {
            var ret = new List<Position>();
            ////
            var p1 = false;
            var p2 = false;
            var p3 = false;
            var p4 = false;
            for (var i = 1; i <= 8; i++)
            {
                if (p1 & p2 & p3 & p4) break;
                ////
                if(!p1)
                    if (list.Exists(f => f.Pos == new Position(Pos.A - i, Pos.B - i)))
                    {
                        p1 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A - i, Pos.B - i)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A - i, Pos.B - i));
                    }
                if (!p1) ret.Add(new Position(Pos.A - i, Pos.B - i));
                ////
                if (!p2)
                    if (list.Exists(f => f.Pos == new Position(Pos.A - i, Pos.B + i)))
                    {
                        p2 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A - i, Pos.B + i)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A - i, Pos.B + i));
                    }
                if (!p2) ret.Add(new Position(Pos.A - i, Pos.B + i));
                ////
                if (!p3)
                    if (list.Exists(f => f.Pos == new Position(Pos.A + i, Pos.B - i)))
                    {
                        p3 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A + i, Pos.B - i)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A + i, Pos.B - i));
                    }
                if (!p3) ret.Add(new Position(Pos.A + i, Pos.B - i));
                ////
                if (!p4)
                    if (list.Exists(f => f.Pos == new Position(Pos.A + i, Pos.B + i)))
                    {
                        p4 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A + i, Pos.B + i)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A + i, Pos.B + i));
                    }
                if (!p4) ret.Add(new Position(Pos.A + i, Pos.B + i));
            }
            ////
            var tret = new List<Position>(ret.Where(p => (p.A >= 1 & p.A <= 8) & (p.B >= 1 & p.B <= 8)));
            return tret;
        }
    }
}