using BingoGame.App.Hepler;
using BingoGame.Core.Manger;
using BingoGame.Core.Utils;
using System;

namespace BingoGame
{
    class Program
    {
        public const int MATRIX_LENGTH = 5;

        static void Main(string[] args)
        {
            var generator = new NumberGenerator();
            var boardManager = new BoardManager(generator, MATRIX_LENGTH);
            var board = boardManager.CreateBoard();

            var stepCounter = 0; //count of steps for cheking winner
            var isGameFinished = false;

            ConsoleHelper.Title();
            ConsoleHelper.RenderBoard(board);
            ConsoleHelper.Footer();

            while (Console.ReadKey().Key != ConsoleKey.Escape && !isGameFinished)
            {
                stepCounter++;
                var nextNumber = generator.Generate();

                //check number on the board
                boardManager.SelectNumberInBoard(board, nextNumber);

                ConsoleHelper.Header(nextNumber, stepCounter);
                ConsoleHelper.RenderBoard(board);

                //check winner
                if (stepCounter >= 5 && boardManager.IsBoardWon(board))
                {
                    isGameFinished = true;
                    ConsoleHelper.WinnerMessage();
                }
                else
                {
                    ConsoleHelper.Footer();
                }
            }
        }
    }
}
