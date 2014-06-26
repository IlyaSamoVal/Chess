using System;
using System.Collections.Generic;

namespace Chess
{
    class Quenn : Figure //ферзь
    {
        public Quenn(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {
        }

        protected override List<Position> GetAvailiblePositions()
        {
            throw new NotImplementedException();
        }
    }
}