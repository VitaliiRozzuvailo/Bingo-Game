using BingoGame.Core.Models;
using BingoGame.Core.Utils;
using System.Linq;

namespace BingoGame.Core.Manger
{
    public class BoardManager
    {
        private readonly INumberGenerator _generator;
        private readonly int _matrixLength;

        public BoardManager(INumberGenerator generator, int matrixLength)
        {
            _generator = generator;
            _matrixLength = matrixLength;
        }

        public Board CreateBoard()
        {
            var card = new Card(_matrixLength);
            card.Fill(_generator);

            var board = new Board();
            board.AddCard(card);

            return board;
        }

        public void SelectNumberInBoard(Board board, int number)
        {
            foreach (var card in board.GetCards())
            {
                var cells = card.GetCells();
                foreach (var cell in cells)
                {
                    var isSelected = cell.IsSelected || cell.Value == number;
                    cell.SetSelected(isSelected);
                }
            }
        }

        public bool IsBoardWon(Board board)
        {
            return board.GetCards()
                .Any(card => card.IsSelectedRow() || 
                             card.IsSelectedColumn() || 
                             card.IsSelectedDiagonal());

        }
    }
}
