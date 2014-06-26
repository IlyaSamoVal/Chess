using System;
using System.Collections.Generic;

namespace Chess
{
    class Pawn : Figure //пешка
    {

        private bool _isMoved;

        public Pawn(int a, int b, bool isBlackColored) : base(a, b, isBlackColored)
        {
            _isMoved = false;
        }

        protected override List<Position> GetAvailiblePositions()
        {
            var i = IsBlackColored ? -1 : 1;
            var ret = new List<Position>
            {
                new Position(Pos.A+i, Pos.B)
            };
            if (!_isMoved) ret.Add(new Position(Pos.A+2*i, Pos.B));
            return ret;
        }

        public bool MakePawnPossibleToAttack(int newA, int newB)
        {
            if ((newB == Pos.A + (IsBlackColored ? -1 : 1)) & (Math.Abs(newB - Pos.B) == 1))
            {
                AvailiblePositions.Add(new Position(newA, newB));
                return true;
            }
            return false;
        }
        public override bool Move(int newA, int newB)
        {
            if(!_isMoved) _isMoved = true;
            return base.Move(newA, newB);
        }
    }
}