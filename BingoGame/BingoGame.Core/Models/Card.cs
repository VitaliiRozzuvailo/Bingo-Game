using BingoGame.Core.Utils;

namespace BingoGame.Core.Models
{
    public class Card
    {
        private readonly Cell[,] _cells;
        private readonly int _matrixLength;

        public Card(int matrixLength)
        {
            _matrixLength = matrixLength;
            _cells = new Cell[matrixLength, matrixLength];
        }

        public Cell[,] GetCells()
        {
            return _cells;
        }

        public void Fill(INumberGenerator generator)
        {
            for (int row = 0; row < _matrixLength; row++)
            {
                for (int col = 0; col < _matrixLength; col++)
                {
                    var value = generator.Generate();
                    _cells[row, col] = new Cell(value);
                }
            }
        }

        public bool IsSelectedRow()
        {
            for (int row = 0; row < _matrixLength; row++)
            {
                var countSelectedCells = 0;
                for (int col = 0; col < _matrixLength; col++)
                {
                    var cell = _cells[row, col];
                    if (cell.IsSelected)
                    {
                        countSelectedCells++;
                    }
                }
                //is selected all row
                if (countSelectedCells == _matrixLength)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSelectedColumn()
        {
            for (int col = 0; col < _matrixLength; col++)
            {
                var countSelectedCells = 0;
                for (int row = 0; row < _matrixLength; row++)
                {
                    var cell = _cells[row, col];
                    if (cell.IsSelected)
                    {
                        countSelectedCells++;
                    }
                }
                if (countSelectedCells == _matrixLength)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsSelectedDiagonal()
        {
            //diagonal from [0,0] to [matrix length,matrix length]
            var countSelectedCells = 0;
            for (int i = 0; i < _matrixLength; i++)
            {
                var cell = _cells[i, i];
                if (cell.IsSelected)
                {
                    countSelectedCells++;
                }
            }
            if (countSelectedCells == _matrixLength)
            {
                return true;
            }

            //diagonal from [0,matrix length] to [matrix length,0]
            countSelectedCells = 0;
            for (int i = 0; i < _matrixLength; i++)
            {
                var col = (_matrixLength - 1) - i;
                var row = i;

                var cell = _cells[row, col];
                if (cell.IsSelected)
                {
                    countSelectedCells++;
                }
            }
            if (countSelectedCells == _matrixLength)
            {
                return true;
            }
            return false;
        }
    }
}
