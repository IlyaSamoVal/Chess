using System.Collections.Generic;

namespace Chess
{
    public class Knight : Figure //конь
    {
        public Knight(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var ret = new List<Position>();
            if ((Pos.A > 1) & (Pos.B > 2)) ret.Add(new Position(Pos.A - 1, Pos.B - 2));
            if ((Pos.A > 1) & (Pos.B < Max - 2)) ret.Add(new Position(Pos.A - 1, Pos.B + 2));

            if ((Pos.A < Max - 1) & (Pos.B < Max - 2)) ret.Add(new Position(Pos.A + 1, Pos.B + 2));
            if ((Pos.A < Max - 1) & (Pos.B > 2)) ret.Add(new Position(Pos.A + 1, Pos.B - 2));

            if ((Pos.A < Max - 2) & (Pos.B < Max - 1)) ret.Add(new Position(Pos.A + 2, Pos.B + 1));
            if ((Pos.A < Max - 2) & (Pos.B > 1)) ret.Add(new Position(Pos.A + 2, Pos.B - 1));

            if ((Pos.A > 2) & (Pos.B < Max - 1)) ret.Add(new Position(Pos.A - 2, Pos.B + 1));
            if ((Pos.A > 2) & (Pos.B > 1)) ret.Add(new Position(Pos.A - 2, Pos.B - 1));

            return ret;
        }
    }
}