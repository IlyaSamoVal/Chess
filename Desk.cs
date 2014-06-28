using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    class Desk
    {
        private List<Figure> _figures;
        public List<Move> Moves { get; private set; } 
        public static Desk ClassicChessDesk()
        {
            var ret= new Desk
            {
                _figures = new List<Figure>
                {
                    new Rook(1, 1, false),
                    new Rook(8, 1, false),
                    new Knight(2, 1, false),
                    new Knight(7, 1, false),
                    new Bishop(3, 1, false),
                    new Bishop(6, 1, false),
                    new Quenn(4, 1, false),
                    new King(5, 1, false)
                }
            };
            for (var i = 1; i <= 8; i++)
            {
                ret._figures.Add(new Pawn(i, 2, false));
            }

            ret._figures.Add(new Rook(1, 8, true));
            ret._figures.Add(new Rook(8, 8, true));
            ret._figures.Add(new Knight(2, 8, true));
            ret._figures.Add(new Knight(7, 8, true));
            ret._figures.Add(new Bishop(3, 8, true));
            ret._figures.Add(new Bishop(6, 8, true));
            ret._figures.Add(new Quenn(5, 8, true));
            ret._figures.Add(new King(4, 8, true));
            for (var i = 1; i <= 8; i++)
            {
                ret._figures.Add(new Pawn(i, 7, true));
            }
            ret.AddEvent();
            return ret;
        }

        private void AddEvent()
        {
            foreach (var figure in _figures)
            {
                figure.HasMoved += figure_HasMoved;
            }
        }

        void figure_HasMoved(Figure figure, Figure.Position oldPosition)
        {
            Moves.Add(new Move {NewPosition = figure.Pos, OldPosition = oldPosition});
            _figures.RemoveAll(p => p.Pos == figure.Pos & p != figure);
        }
    }
}
