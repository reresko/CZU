using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Model
{
    internal class GameBoard
    {
        public Cell[,] Cells {  get; private set; }
        public int Rows { get; }
        public int Columns { get; }
        public int MineCount { get; }

        public GameBoard(int rows, int columns, int mineCount)
        {
            Rows = rows;
            Columns = columns;
            MineCount = mineCount;
            Cells = new Cell[Rows, Columns];
            InitializeBoard();
            PlaceMines();
            CalculateAdjacentMines();
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for(int column = 0; column < Columns; column++)
                {
                    Cells[row, column] = new Cell
                    {
                        Row = row,
                        Column = column,
                        IsMine = false,
                        AdjacentMines = 0,
                        IsRevealed = false,
                        IsFlagged = false,
                    };
                }
            }
        }

        private void PlaceMines()
        {
            Random random = new Random();
            int placedMines = 0;

            while (placedMines < MineCount)
            {
                int row = random.Next(Rows);
                int column = random.Next(Columns);

                if (!Cells[row, column].IsMine)
                {
                    Cells[row, column].IsMine = true;
                    placedMines++;
                }
            }
        }

        private IEnumerable<Cell> GetNeighbors(int row, int column)
        {
            int[] possibleNeighborsRow = [-1, -1, -1, 0, 0, 1, 1, 1];
            int[] possibleNeighborColumn = [-1, 0, 1, -1, 1, -1, 0, 1];

            for (int i = 0; i < possibleNeighborsRow.Length; i++)
            {
                int newRow = row + possibleNeighborsRow[i];
                int newColumn = column + possibleNeighborColumn[i];

                if (newRow >= 0 && newRow < Rows && newColumn >= 0 && newColumn < Columns)
                {
                    yield return Cells[newRow, newColumn];
                }

            }
        }

        private void CalculateAdjacentMines()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (Cells[row, column].IsMine) continue;

                    Cells[row, column].AdjacentMines = GetNeighbors(row, column).Count(cell => cell.IsMine);
                }
            }
        }

        public void RevealCell(int row, int column)
        {
            var cell = Cells[row, column];

            if (cell.IsRevealed || cell.IsFlagged)
                return;
            
            cell.IsRevealed = true;

            if (cell.IsMine)
            {
                Console.WriteLine("game over");
                return;
            }

            if (cell.AdjacentMines == 0)
            {
                foreach (var neighbor in GetNeighbors(row, column))
                {
                    if (!neighbor.IsRevealed)
                    {
                        RevealCell(neighbor.Row, neighbor.Column);
                    }
                }
            }
        }

        public void ToggleFlag(int row, int column)
        {
            var cell = Cells[row, column];

            if (cell.IsRevealed)
            {
                cell.IsFlagged = !cell.IsFlagged;
            }
        }

        public bool CheckWin()
        {
            foreach (var cell in Cells)
            {
                if (!cell.IsMine || cell.IsRevealed)
                    return false;
            }

            return true;
        }
    }
}