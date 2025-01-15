using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Schema;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Generates and manages buttons on the Minesweeper game board.
    /// </summary>
    internal class ButtonGenerator
    {
        // creating variables
        private Panel _panelGameField;
        private GameLogic _gameLogic;
        private AutoRevealEmpty _autoRevealEmpty;
        private TextBoxHandler _flagsHandler;
        private TextBoxHandler _scoreHandler;
        private CellColor _cellColor;
        private RevealAllCells _revealAllCells;
        private Timer _timer;

        /// <summary>
        /// Initializes the ButtonGenerator with required dependencies.
        /// </summary>
        /// <param name="panelGameField">The panel where game buttons will be displayed.</param>
        /// <param name="gameLogic">Game logic object managing the game's state.</param>
        /// <param name="autoRevealEmpty">Handles revealing of adjacent empty cells.</param>
        /// <param name="flagsHandler">Manages the display of the remaining flag count.</param>
        /// <param name="scoreHandler">Manages the display of the player's score.</param>
        /// <param name="cellColor">Provides cell colors based on mine counts.</param>
        /// <param name="revealAllCells">Handles revealing all cells when the game ends.</param>
        /// <param name="timer">Tracks elapsed game time.</param>
        public ButtonGenerator(Panel panelGameField, GameLogic gameLogic, AutoRevealEmpty autoRevealEmpty, TextBoxHandler flagsHandler, TextBoxHandler scoreHandler, CellColor cellColor, RevealAllCells revealAllCells, Timer timer)
        {
            _panelGameField = panelGameField;
            _gameLogic = gameLogic;
            _autoRevealEmpty = autoRevealEmpty;
            _flagsHandler = flagsHandler;
            _scoreHandler = scoreHandler;
            _cellColor = cellColor;
            _revealAllCells = revealAllCells;
            _timer = timer;
        }

        /// <summary>
        /// Generates a grid of buttons for the Minesweeper game board.
        /// </summary>
        /// <param name="columns">Number of columns in the game board.</param>
        /// <param name="rows">Number of rows in the game board.</param>
        public void GenerateButtons(int columns, int rows)
        {
            //enable the panel and clear previous buttons
            _panelGameField.Enabled = true;
            _panelGameField.Controls.Clear();

            //panel size based on # of columns and rows
            _panelGameField.Width = columns * 30;
            _panelGameField.Height = rows * 30;

            //create buttons for each cell in da grid
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    CustomButton btn = new CustomButton();
                    btn.Width = 30;
                    btn.Height = 30;
                    btn.Left = x * 30;
                    btn.Top = y * 30;
                    btn.Tag = new Tuple<int, int>(x, y); //store coords inside buttons Tag as tuple

                    //connect event handlers for left and right click
                    btn.Click += (sender, e) => OnButtonClick(sender, e);
                    btn.MouseUp += (sender, e) => OnButtonMouseUp(sender, e);
                    _panelGameField.Controls.Add(btn);
                }
            }
        }

        /// <summary>
        /// Handles left-click events on game board buttons.
        /// </summary>
        private void OnButtonClick(object sender, EventArgs e)
        {
            CustomButton btn = sender as CustomButton;
            if (btn != null)
            {
                //ignore if flag
                if (btn.IsFlag)
                    return;

                //get coords of the cell
                var coordinates = (Tuple<int, int>)btn.Tag;
                int x = coordinates.Item1;
                int y = coordinates.Item2;

                int minesCountCell = _gameLogic.Positions[x, y];

                //reveal cell
                btn.BackColor = Color.LightGray;

                //if the cell is a mine
                if (minesCountCell == 10)
                {
                    TimeSpan gameTime = _timer.GetElapsedTime();
                    btn.Image = Properties.Resources.mine;
                    _timer.TimerStop();
                    _revealAllCells.RevealAll();
                    MessageBox.Show($"Game Over!\nTime Spent: {gameTime.Minutes:D2}:{gameTime.Seconds:D2}", "Lose", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _panelGameField.Enabled = false;
                }
                //if the cell is empty
                else if (minesCountCell == 0)
                {
                    _autoRevealEmpty.RevealAdjacentCells(x, y);
                }
                else
                {
                    btn.Text = minesCountCell.ToString();
                    btn.ForeColor = _cellColor.GetMineCountColor(minesCountCell);
                }
                //only if the cell is not already revealed and is not mine
                if (btn.CustomEnabled && minesCountCell != 10)
                {
                    _gameLogic.IncrementRevealedCells();
                    int score = _gameLogic.RevealedCellsCount;
                    _scoreHandler.SetValue(score);
                    btn.CustomEnabled = false; //disable further interaction with the button
                }

                //checks win
                if (_gameLogic.CheckWin())
                {
                    TimeSpan gameTime = _timer.GetElapsedTime();
                    MessageBox.Show($"You Won!\nTime Spent: {gameTime.Minutes:D2}:{gameTime.Seconds:D2}", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _panelGameField.Enabled = false;
                    _gameLogic.RevealedCellsCount = 0;
                }
            }
        }

        /// <summary>
        /// Handles right-click events for flagging/unflagging cells.
        /// </summary>
        private void OnButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CustomButton btn = sender as CustomButton;
                if (btn != null && btn.CustomEnabled)
                {
                    int FlagsAvailable = _flagsHandler.GetValue();

                    if (!btn.IsFlag && FlagsAvailable > 0)
                    {
                        btn.IsFlag = true;
                        btn.Image = Properties.Resources.flag;
                        FlagsAvailable--;
                        _flagsHandler.SetValue(FlagsAvailable);
                    }
                    else if (btn.IsFlag)
                    {
                        btn.IsFlag = false;
                        btn.Image = null;
                        FlagsAvailable++;
                        _flagsHandler.SetValue(FlagsAvailable);
                    }
                    else
                        return;
                }
            }
        }
    }
}
