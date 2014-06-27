using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Figure //слон
    {
        public Bishop(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var ret = new List<Position>();
            for (int i = 1; i <= Max; i++)
            {
                ret.Add(new Position(Pos.A - i, Pos.B - i));
                ret.Add(new Position(Pos.A - i, Pos.B + i));
                ret.Add(new Position(Pos.A + i, Pos.B - i));
                ret.Add(new Position(Pos.A + i, Pos.B + i));
            }
            var tret = new List<Position>(ret.Where(p => (p.A >= 1 & p.A <= Max) & (p.B >= 1 & p.B <= Max)));
            return tret;
        }
    }
}