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

        public ButtonGenerator(Panel panelGameField, GameLogic gameLogic, AutoRevealEmpty autoRevealEmpty)
        {
            _panelGameField = panelGameField;
            _gameLogic = gameLogic;
            _autoRevealEmpty = autoRevealEmpty;
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
                    Button btn = new Button
                    {
                        Width = 30,
                        Height = 30,
                        Left = x * 30,
                        Top = y * 30,
                        Tag = new Tuple<int, int>(x, y)
                    };

                    //btn.Click += (sender, e) => OnButtonClick(sender, e, x, y);
                    btn.Click += (sender, e) => OnButtonClick(sender, e);
                    btn.MouseUp += (sender, e) => OnButtonMouseUp(sender, e);
                    _panelGameField.Controls.Add(btn);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Text == "F")
                    return;

                var coordinates = (Tuple<int, int>)btn.Tag;
                int x = coordinates.Item1;
                int y = coordinates.Item2;

                int minesCountCell = _gameLogic.Positions[x, y];

                btn.BackColor = Color.LightGray;

                if (minesCountCell == 10)
                {
                    btn.Text = "X";
                    MessageBox.Show("game over");
                    _panelGameField.Enabled = false;
                }
                else if (minesCountCell == 0)
                {
                    _autoRevealEmpty.RevealAdjacentCells(x, y);
                }
                else
                {
                    btn.Text = minesCountCell.ToString();
                    btn.ForeColor = GetMineCountColor(minesCountCell);
                }

                if (btn.Enabled)
                {
                    _gameLogic.IncrementRevealedCells();
                    btn.Enabled = false;
                }

                if (_gameLogic.CheckWin())
                {
                    MessageBox.Show("you won");
                    _panelGameField.Enabled = false;
                    _gameLogic.RevealedCellsCount = 0;
                }
            }
        }

        private void OnButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = sender as Button;
                if (btn != null && btn.Enabled)
                {
                    if (btn.Text == "F")
                    {
                        btn.Text = "";
                    }
                    else
                    {
                        btn.Text = "F";
                        btn.ForeColor = Color.Red;
                    }
                }
            }
        }

        public Color GetMineCountColor(int count)
        {
            return count switch
            {
                1 => Color.Blue,
                2 => Color.Green,
                3 => Color.Red,
                4 => Color.DarkBlue,
                5 => Color.DarkRed,
                6 => Color.Cyan,
                7 => Color.Black,
                _ => Color.Gray,
            };
        }
    }
}
