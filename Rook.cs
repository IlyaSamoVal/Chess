using System.Collections.Generic;

namespace Chess
{
    class Rook : Figure //ладья
    {
        public Rook(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {

        }

        protected override List<Position> GetAvailiblePositions()
        {
            throw new System.NotImplementedException();
        }
    }
}