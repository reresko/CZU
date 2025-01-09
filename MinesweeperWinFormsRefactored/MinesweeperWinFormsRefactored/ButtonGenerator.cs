using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MinesweeperWinFormsRefactored
{
    internal class ButtonGenerator
    {
        private Panel _panelGameField;
        private GameLogic _gameLogic;
        private AutoRevealEmpty _autoRevealEmpty;
        private TextBoxHandler _flagsHandler;
        private TextBoxHandler _scoreHandler;
        private CellColor _cellColor;
        private RevealAllCells _revealAllCells;

        public ButtonGenerator(Panel panelGameField, GameLogic gameLogic, AutoRevealEmpty autoRevealEmpty, TextBoxHandler flagsHandler, TextBoxHandler scoreHandler, CellColor cellColor, RevealAllCells revealAllCells)
        {
            _panelGameField = panelGameField;
            _gameLogic = gameLogic;
            _autoRevealEmpty = autoRevealEmpty;
            _flagsHandler = flagsHandler;
            _scoreHandler = scoreHandler;
            _cellColor = cellColor;
            _revealAllCells = revealAllCells;
        }

        public void GenerateButtons(int columns, int rows)
        {
            _panelGameField.Enabled = true;
            _panelGameField.Controls.Clear();

            _panelGameField.Width = columns * 30;
            _panelGameField.Height = rows * 30;

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    CustomButton btn = new CustomButton();
                    btn.Width = 30;
                    btn.Height = 30;
                    btn.Left = x * 30;
                    btn.Top = y * 30;
                    btn.Tag = new Tuple<int, int>(x, y);

                    //btn.Click += (sender, e) => OnButtonClick(sender, e, x, y);
                    btn.Click += (sender, e) => OnButtonClick(sender, e);
                    btn.MouseUp += (sender, e) => OnButtonMouseUp(sender, e);
                    _panelGameField.Controls.Add(btn);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            CustomButton btn = sender as CustomButton;
            if (btn != null)
            {
                if (btn.IsFlag)
                    return;

                var coordinates = (Tuple<int, int>)btn.Tag;
                int x = coordinates.Item1;
                int y = coordinates.Item2;

                int minesCountCell = _gameLogic.Positions[x, y];

                btn.BackColor = Color.LightGray;

                if (minesCountCell == 10)
                {
                    btn.Image = Properties.Resources.mine;
                    _revealAllCells.RevealAll();
                    MessageBox.Show("Game Over!", "Lose", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _panelGameField.Enabled = false;
                }
                else if (minesCountCell == 0)
                {
                    _autoRevealEmpty.RevealAdjacentCells(x, y);
                }
                else
                {
                    btn.Text = minesCountCell.ToString();
                    btn.ForeColor = _cellColor.GetMineCountColor(minesCountCell);
                }

                if (btn.CustomEnabled)
                {
                    _gameLogic.IncrementRevealedCells();
                    int score = _gameLogic.RevealedCellsCount;
                    _scoreHandler.SetValue(score);
                    btn.CustomEnabled = false;
                }

                if (_gameLogic.CheckWin())
                {
                    MessageBox.Show("You Won!", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _panelGameField.Enabled = false;
                    _gameLogic.RevealedCellsCount = 0;
                }
            }
        }

        private void OnButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CustomButton btn = sender as CustomButton;
                if (btn != null && btn.Enabled)
                {
                    int FlagsAvailable = _flagsHandler.GetValue();

                    if (btn.IsFlag)
                    {
                        btn.IsFlag = false;
                        btn.Image = null;
                        FlagsAvailable++;
                        _flagsHandler.SetValue(FlagsAvailable);
                    }
                    else
                    {
                        btn.IsFlag = true;
                        btn.Image = Properties.Resources.flag;
                        FlagsAvailable--;
                        _flagsHandler.SetValue(FlagsAvailable);
                    }
                }
            }
        }
    }
}
