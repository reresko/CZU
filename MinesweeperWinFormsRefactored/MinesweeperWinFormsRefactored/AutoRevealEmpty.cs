using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Handles the automatic reveal of adjacent empty cells when a cell with no surrounding mines is clicked.
    /// </summary>
    internal class AutoRevealEmpty
    {
        //creating variables
        private GameLogic _gameLogic;
        private Panel _panelGameField;
        private HashSet<(int, int)> _visitedCells; //tracks visited cells to avoid infinite loop
        private CellColor _cellColor; //handles cell colors based on mine counts
        private TextBoxHandler _scoreHandler; //manages the display of the player's score

        /// <summary>
        /// Initializes the AutoRevealEmpty instance with game logic, game field, score handler, and cell color settings.
        /// </summary>
        /// <param name="gameLogic">GameLogic instance to track game state.</param>
        /// <param name="panelGameField">Panel representing the game board.</param>
        /// <param name="scoreHandler">TextBoxHandler to manage score updates.</param>
        /// <param name="cellColor">CellColor instance for managing colors based on mine counts.</param>
        public AutoRevealEmpty(GameLogic gameLogic, Panel panelGameField, TextBoxHandler scoreHandler, CellColor cellColor)
        {
            _gameLogic = gameLogic;
            _panelGameField = panelGameField;
            _visitedCells = new HashSet<(int, int)>();
            _scoreHandler = scoreHandler;
            _cellColor = cellColor;
        }

        /// <summary>
        /// Recursively reveals all adjacent cells that do not contain mines, starting from the given cell coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate of the cell.</param>
        /// <param name="y">The Y-coordinate of the cell.</param>
        public void RevealAdjacentCells(int x, int y)
        {
            //boundary check to ensure the cell is within the game field
            if (x < 0 || x >= _gameLogic.ColumnsCount || y < 0 || y >= _gameLogic.RowsCount)
                return;

            //ignore visited cells
            if (_visitedCells.Contains((x, y)))
                return;

            //add current cell to visited
            _visitedCells.Add((x, y));

            //locate the corresponding button on the game panel
            CustomButton btn = _panelGameField.Controls
                .OfType<CustomButton>()
                .FirstOrDefault(b => ((Tuple<int, int>)b.Tag).Item1 == x && ((Tuple<int, int>)b.Tag).Item2 == y);

            //skip null or disabled buttons
            if (btn == null || !btn.Enabled)
                return;

            int minesCountCell = _gameLogic.Positions[x, y];

            //skip for cell with mine inside
            if (minesCountCell == 10)
                return;

            btn.Text = minesCountCell == 0 ? "" : minesCountCell.ToString();
            btn.BackColor = Color.LightGray;
            btn.ForeColor = _cellColor.GetMineCountColor(minesCountCell);

            //update the game state and score if the button is enabled
            if (btn.CustomEnabled)
            {
                _gameLogic.IncrementRevealedCells();
                int score = _gameLogic.RevealedCellsCount;
                _scoreHandler.SetValue(score);
                btn.CustomEnabled = false;
            }

            //checks win and shows messagebox
            if (_gameLogic.CheckWin())
            {
                MessageBox.Show("you won");
                _panelGameField.Enabled = false;
                _gameLogic.ResetRevealedCellsCount();
                return;
            }

            //recursively reveal all cells that have no surrounding mine
            if (minesCountCell == 0)
            {
                for (int counterX = -1; counterX <= 1; counterX++)
                {
                    for (int counterY = -1; counterY <= 1; ++counterY)
                    {
                        if (counterX == 0 && counterY == 0)
                            continue;
                        
                        RevealAdjacentCells(x + counterX, y + counterY);
                    }
                }
            }
        }

        /// <summary>
        /// Resets visited cells, clearing the game state for next game.
        /// </summary>
        public void Reset()
        {
            _visitedCells.Clear();
        }
    }
}
