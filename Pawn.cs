using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Figure //пешка
    {
        public bool IsMoved { get; private set; }

        public Pawn(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
            IsMoved = false;
        }

        internal override List<Position> GetAvailiblePositions(List<Figure> list)
        {
            var ret = new List<Position>();
            ////
            var i = IsBlackColored ? -1 : 1;
            ////
            if (!list.Exists(f => f.Pos == new Position(Pos.A, Pos.B+i)))
            {
                ret.Add(new Position(Pos.A, Pos.B+i));
                if (!IsMoved) ret.Add(new Position(Pos.A, Pos.B + 2*i));
            }
            ////
            if (list.Exists(f => f.Pos == new Position(Pos.A + 1, Pos.B+i)))
                ret.Add(new Position(Pos.A + 1, Pos.B + i));
            ////
            if (list.Exists(f => f.Pos == new Position(Pos.A -1, Pos.B +i)))
                ret.Add(new Position(Pos.A - 1, Pos.B + i));
            ////
            var tret = new List<Position>(ret.Where(p => (p.A >= 1 & p.A <= 8) & (p.B >= 1 & p.B <= 8)));
            return tret;
        }
        public override bool Move(int newA, int newB)
        {
            var b=base.Move(newA, newB);
            if (b & !IsMoved) IsMoved = true;
            return b;
        }
    }
}