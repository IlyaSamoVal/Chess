using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Bishop : Figure //слон
    {
        public Bishop(int a, int b, bool isBlackColored=false) : base(a, b, isBlackColored)
        {
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var ret = new List<Position>();
            for (var i = 1; i <= 8; i++)
            {
                ret.Add(new Position(Pos.A - i, Pos.B - i));
                ret.Add(new Position(Pos.A - i, Pos.B + i));
                ret.Add(new Position(Pos.A + i, Pos.B - i));
                ret.Add(new Position(Pos.A + i, Pos.B + i));
            }
            var tret = new List<Position>(ret.Where(p => (p.A >= 1 & p.A <= 8) & (p.B >= 1 & p.B <= 8)));
            return tret;
        }
    }
}