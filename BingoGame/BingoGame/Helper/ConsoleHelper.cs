using BingoGame.Core.Models;
using System;

namespace BingoGame.App.Hepler
{
    internal class ConsoleHelper
    {
        public static void Title()
        {
            Console.WriteLine();
            Console.WriteLine("\t╔════╦════╦════╦════╦════╦════╦════╦════╦════╦════╗");
            Console.WriteLine("\t║ B  ║ I  ║ N  ║ G  ║ O  ║    ║ G  ║ A  ║ M  ║ E  ║");
            Console.WriteLine("\t╚════╩════╩════╩════╩════╩════╩════╩════╩════╩════╝");
            Console.WriteLine();
            Console.WriteLine("Description: The game has infinitive steps so you will always win :)");
            Console.WriteLine();
        }

        public static void Header(int nextValue, int steps)
        {
            Console.ResetColor();

            Console.WriteLine();

            Console.Write("Step: ");
            Console.Write(steps);
            Console.WriteLine();
            Console.Write("Next number: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(nextValue);

            Console.WriteLine();
        }

        public static void Footer()
        {
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Press any key to next step or ESCAPE to exit ...");
            Console.WriteLine();
        }

        public static void RenderBoard(Board board)
        {
            var length = board.GetCardsLength();
            if (length > 1)
            {
                throw new NotImplementedException("Card should be only one on the board. This application supports only one card for now.");
            }

            var card = board.GetFirstCard();
            var cells = card.GetCells();

            Console.ResetColor();

            Console.WriteLine("Your card:");
            Console.WriteLine("╔════╦════╦════╦════╦════╗");

            for (int row = 0; row < Program.MATRIX_LENGTH; row++)
            {
                for (int col = 0; col < Program.MATRIX_LENGTH; col++)
                {
                    Console.ResetColor();
                    Console.Write("║");

                    var cell = cells[row, col];
                    if (cell.IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    var valueAsStr = cell.Value < 10 ? $" {cell.Value}  " : $" {cell.Value} ";
                    Console.Write(valueAsStr);
                }

                Console.ResetColor();
                Console.Write("║");
                Console.WriteLine("");

                var isLastRow = row < (Program.MATRIX_LENGTH - 1);
                if (isLastRow)
                {
                    Console.WriteLine("╠════╬════╬════╬════╬════╣");
                }
            }

            Console.WriteLine("╚════╩════╩════╩════╩════╝");
        }

        public static void WinnerMessage()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine("CONGRATULATIONS, YOU WON! ");
            Console.WriteLine();

            Console.ResetColor();
            Console.WriteLine("Press any key to exit ...");
            Console.WriteLine();
        }
    }
}
