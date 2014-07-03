using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Desk
    {
        private List<Figure> _figures;
        public List<Move> Moves { get; private set; }

        public delegate void Won(bool isBlack);

        public event Won HasWon;



        public static Desk ClassicChessDesk()
        {
            var ret = new Desk
            {
                _figures = new List<Figure>
                {
                    //White
                    new Rook(1, 1),
                    new Rook(8, 1),
                    new Knight(2, 1),
                    new Knight(7, 1),
                    new Bishop(3, 1),
                    new Bishop(6, 1),
                    new Quenn(4, 1),
                    new King(5, 1),
                    //Black
                    new Rook(1, 8, true),
                    new Rook(8, 8, true),
                    new Knight(2, 8, true),
                    new Knight(7, 8, true),
                    new Bishop(3, 8, true),
                    new Bishop(6, 8, true),
                    new Quenn(5, 8, true),
                    new King(4, 8, true)
                },
                Moves = new List<Move>()
            };
            for (var i = 1; i <= 8; i++)
            {
                ret._figures.Add(new Pawn(i, 2));
            }

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

        private void figure_HasMoved(Figure figure, Position oldPosition)
        {
            Moves.Add(new Move {NewPosition = figure.Pos, OldPosition = oldPosition});
            _figures.RemoveAll(p => p.Pos == figure.Pos & p != figure);
        }

        public List<Position> GetAvailiblePositions(Position position)
        {
            if (_figures.Single(f => f.Pos == position).GetType() == typeof (King))
                return _figures.Single(f => f.Pos == position).GetAvailiblePositions(_figures);
            return
                (List<Position>)
                    _figures.Single(f => f.Pos == position)
                        .GetAvailiblePositions(_figures)
                        .Except(GetAllAvailiblePositionsExcept(_figures.Single(f => f.Pos == position)));
        }

        private IEnumerable<Position> GetAllAvailiblePositionsExcept(Figure single)
        {
            var ret = new List<Position>();
            foreach (var figure in _figures.Where(f => !(f.IsBlackColored ^ single.IsBlackColored)))
            {
                ret.AddRange(figure.GetAvailiblePositions(_figures));
            }
            return ret;
        }

        public List<Position> GetBlackPositions()
        {
            return _figures.Where(f => f.IsBlackColored).Select(figure => figure.Pos).ToList();
        }

        public List<Position> GetWhitePositions()
        {
            return _figures.Where(f => !f.IsBlackColored).Select(figure => figure.Pos).ToList();
        }

        public bool MoveFigure(Position figurePosition, Position newPosition)
        {
            var ret = _figures.Single(f => f.Pos == figurePosition).Move(newPosition);
            CheckWinStatement();
            return ret;
        }

        private void CheckWinStatement()
        {
            CheckWhiteWin();
            CheckBlackWin();
        }

        private void CheckWhiteWin()
        {
            var wk = _figures.Single(f => f.GetType() == typeof (King) & !f.IsBlackColored);
            if (GetAvailiblePositions(wk.Pos).Count != 0) return;
            if (
                _figures
                    .Where(f => f.IsBlackColored)
                    .Any(figure => GetAvailiblePositions(figure.Pos)
                        .Contains(wk.Pos)))
                HasWon(true);
        }

        private void CheckBlackWin()
        {
            var wk = _figures.Single(f => f.GetType() == typeof (King) & f.IsBlackColored);
            if (GetAvailiblePositions(wk.Pos).Count != 0) return;
            if (_figures.Where(f => !f.IsBlackColored)
                .Any(figure => GetAvailiblePositions(figure.Pos)
                    .Contains(wk.Pos)))
                HasWon(false);
        }
    }
}
