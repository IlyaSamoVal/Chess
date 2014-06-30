using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    internal class Rook : Figure //ладья
    {

        public bool IsMoved { get; private set; }

        public Rook(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
            IsMoved = false;
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
                if (!p1)
                    if (list.Exists(f => f.Pos == new Position(Pos.A - i, Pos.B)))
                    {
                        p1 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A - i, Pos.B)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A - i, Pos.B));
                    }
                if (!p1) ret.Add(new Position(Pos.A - i, Pos.B));
                ////
                if (!p2)
                    if (list.Exists(f => f.Pos == new Position(Pos.A + i, Pos.B)))
                    {
                        p2 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A + i, Pos.B)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A + i, Pos.B));
                    }
                if (!p2) ret.Add(new Position(Pos.A + i, Pos.B));
                ////
                if (!p3)
                    if (list.Exists(f => f.Pos == new Position(Pos.A, Pos.B - i)))
                    {
                        p3 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A, Pos.B - i)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A, Pos.B - i));
                    }
                if (!p3) ret.Add(new Position(Pos.A, Pos.B - i));
                ////
                if (!p4)
                    if (list.Exists(f => f.Pos == new Position(Pos.A, Pos.B + i)))
                    {
                        p4 = true;
                        if (!list.Single(f => f.Pos == new Position(Pos.A, Pos.B + i)).IsBlackColored ^
                            IsBlackColored)
                            ret.Add(new Position(Pos.A, Pos.B + i));
                    }
                if (!p4) ret.Add(new Position(Pos.A, Pos.B + i));
            }
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