using System;
using System.Collections.Generic;

namespace Chess
{
    class Bishop : Figure //слон
    {
        public Bishop(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {
        }

        protected override List<Position> GetAvailiblePositions()
        {
            throw new NotImplementedException();
        }
    }
}