using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Handles the core logic of the Minesweeper game, including board initialization, bomb placement, 
    /// and checking game states like winning conditions.
    /// </summary>
    internal class GameLogic
    {
        /// <summary>
        /// Number of columns (x-axis) on the game board, set based on difficulty.
        /// </summary>
        public int ColumnsCount { get; set; }
        /// <summary>
        /// Number of rows (y-axis) on the game board, set based on difficulty.
        /// </summary>
        public int RowsCount { get; set; }
        /// <summary>
        /// Number of bombs to be placed on the game board, set based on difficulty.
        /// </summary>
        public int MinesCount { get; set; }
        /// <summary>
        /// 2D array representing the game board. Each cell contains:
        /// - 10: A bomb.
        /// - 0-8: Number of adjacent bombs.
        /// </summary>
        public int[,] Positions { get; set; }
        /// <summary>
        /// Total number of cells on the game board.
        /// </summary>
        public int TotalCells => RowsCount * ColumnsCount;
        /// <summary>
        /// Number of cells that have been revealed by the player.
        /// </summary>
        public int RevealedCellsCount { get; set; } = 0;

        Random random = new Random();

        /// <summary>
        /// Resets the count of revealed cells to zero.
        /// </summary>
        public void ResetRevealedCellsCount()
        {
            RevealedCellsCount = 0;
        }

        /// <summary>
        /// Initializes the dimensions of the game board and validates them.
        /// This is called whenever a new game starts.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if dimensions are not greater than 0.</exception>
        public void InitializeBoardDimensions()
        {
            if (ColumnsCount <= 0 || RowsCount <= 0)
                throw new InvalidOperationException("Rozměry hrací desky musí být větší než 0!");

            Positions = new int[ColumnsCount, RowsCount];
        }

        /// <summary>
        /// Randomly places bombs on the game board.
        /// Ensures the number of bombs matches <see cref="MinesCount"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the game board is not initialized.</exception>
        public void GenerateBombs()
        {
            if (Positions == null)
                throw new InvalidOperationException("Hrací plocha nebyla inicializována!");

            int bombs = 0;

            while (bombs < MinesCount)
            {
                int x = random.Next(0, ColumnsCount);
                int y = random.Next(0, RowsCount);

                //if there is no mine in the cell
                if (Positions[x, y] == 0)
                {
                    Positions[x, y] = 10;
                    bombs++;
                }
            }
        }

        /// <summary>
        /// Calculates the number of adjacent bombs for each cell on the game board.
        /// Updates cells with a count (0-8) unless they contain a bomb.
        /// </summary>
        public void CalculateAdjacentMines()
        {
            for (int y = 0; y < RowsCount; y++)
            {
                for (int x = 0; x < ColumnsCount; x++)
                {
                    byte bombCount = 0;

                    //check all neighbors around the current cell
                    for (int counterX = -1; counterX <= 1; counterX++)
                    {
                        for (int counterY = -1; counterY <= 1; ++counterY)
                        {
                            if (counterX == 0 && counterY == 0)
                                continue;

                            int neighborX = x + counterX;
                            int neighborY = y + counterY;

                            //ensure the neighbor is within the game board boundaries
                            if (neighborX >= 0 && neighborX < ColumnsCount && neighborY >= 0 && neighborY < RowsCount)
                            {
                                if (Positions[neighborX, neighborY] == 10)
                                    bombCount++;
                            }
                        }
                    }

                    //update the current cell with the bomb count, unless it contains a bomb
                    if (Positions[x, y] != 10)
                    {
                        Positions[x, y] = bombCount;
                    }
                }
            }
        }
        /// <summary>
        /// Increments the count of revealed cells.
        /// Called whenever a player successfully reveals a cell.
        /// </summary>
        public void IncrementRevealedCells()
        {
            RevealedCellsCount++;
        }

        /// <summary>
        /// Checks if the player has won the game.
        /// Winning occurs when all non-bomb cells are revealed.
        /// </summary>
        /// <returns>True if the player has won, otherwise false.</returns>
        public bool CheckWin()
        {
            return RevealedCellsCount == TotalCells - MinesCount;
        }
    }
}
