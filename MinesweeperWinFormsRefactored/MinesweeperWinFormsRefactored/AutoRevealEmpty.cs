using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    internal class AutoRevealEmpty
    {
        private GameLogic _gameLogic;
        private Panel _panelGameField;
        private HashSet<(int, int)> _visitedCells;
        public ButtonGenerator _buttonGenerator;
        public AutoRevealEmpty(GameLogic gameLogic, Panel panelGameField)
        {
            _gameLogic = gameLogic;
            _panelGameField = panelGameField;
            _visitedCells = new HashSet<(int, int)>();
        }

        public AutoRevealEmpty(GameLogic gameLogic, Panel panelGameField, ButtonGenerator buttonGenerator)
        {
            _gameLogic = gameLogic;
            _panelGameField = panelGameField;
            _visitedCells = new HashSet<(int, int)>();
            _buttonGenerator = buttonGenerator;
        }

        public void RevealAdjacentCells(int x, int y)
        {
            if (x < 0 || x >= _gameLogic.ColumnsCount || y < 0 || y >= _gameLogic.RowsCount)
                return;

            if (_visitedCells.Contains((x, y)))
                return;

            _visitedCells.Add((x, y));

            Button btn = _panelGameField.Controls
                .OfType<Button>()
                .FirstOrDefault(b => ((Tuple<int, int>)b.Tag).Item1 == x && ((Tuple<int, int>)b.Tag).Item2 == y);

            if (btn == null || !btn.Enabled)
                return;

            int minesCountCell = _gameLogic.Positions[x, y];

            if (minesCountCell == 10)
                return;

            btn.Text = minesCountCell == 0 ? "" : minesCountCell.ToString();
            btn.BackColor = Color.LightGray;
            btn.ForeColor = _buttonGenerator.GetMineCountColor(minesCountCell);
            _gameLogic.IncrementRevealedCells();

            if (_gameLogic.CheckWin())
            {
                MessageBox.Show("you won");
                _panelGameField.Enabled = false;
                _gameLogic.ResetRevealedCellsCount();
                return;
            }

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

        public void Reset()
        {
            _visitedCells.Clear();
        }
    }
}
