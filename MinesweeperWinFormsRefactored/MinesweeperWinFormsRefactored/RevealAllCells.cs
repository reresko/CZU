using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Responsible for revealing all cells on the game board, typically when the game ends.
    /// </summary>
    internal class RevealAllCells
    {
        private Panel _panelGameField;
        private CellColor _cellColor;
        private GameLogic _gameLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevealAllCells"/> class.
        /// </summary>
        /// <param name="panelGameField">The panel containing the game's buttons (cells).</param>
        /// <param name="cellColor">Utility for determining the color of numbers based on the mine count.</param>
        /// <param name="gameLogic">Manages the internal game logic and board state.</param>
        public RevealAllCells(Panel panelGameField, CellColor cellColor, GameLogic gameLogic)
        {
            _panelGameField = panelGameField;
            _cellColor = cellColor;
            _gameLogic = gameLogic;
        }

        /// <summary>
        /// Reveals all cells on the game board.
        /// Used at the end of the game to show the entire board.
        /// </summary>
        public void RevealAll()
        {
            //iterate through all buttons in the panel, assuming they are of type CustomButton
            foreach (CustomButton btn in _panelGameField.Controls.OfType<CustomButton>())
            {
                //retrieve the cell's coords from the button's Tag property
                var coordinates = (Tuple<int, int>)btn.Tag;
                int x = coordinates.Item1;
                int y = coordinates.Item2;

                //retrieve the cell value from the game logic
                int CellValue = _gameLogic.Positions[x, y];

                //change the cell's background color to indicate it is revealed
                btn.BackColor = Color.LightGray;

                //if cell contains a mine, display mine img
                if (CellValue == 10)
                {
                    btn.Image = Properties.Resources.mine;
                }
                //if cell is empty, leave it blank
                else if (CellValue == 0)
                {
                    btn.Text = "";
                }
                //if cell has mine count, display it with the corresponding color
                else
                {
                    btn.Text = CellValue.ToString();
                    btn.ForeColor = _cellColor.GetMineCountColor(CellValue);
                }
            }
        }
    }
}
