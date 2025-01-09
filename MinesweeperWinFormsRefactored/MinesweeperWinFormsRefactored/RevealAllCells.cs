using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    internal class RevealAllCells
    {
        private Panel _panelGameField;
        private CellColor _cellColor;
        private GameLogic _gameLogic;

        public RevealAllCells(Panel panelGameField, CellColor cellColor, GameLogic gameLogic)
        {
            _panelGameField = panelGameField;
            _cellColor = cellColor;
            _gameLogic = gameLogic;
        }

        public void RevealAll()
        {

            foreach (CustomButton btn in _panelGameField.Controls.OfType<CustomButton>())
            {
                var coordinates = (Tuple<int, int>)btn.Tag;
                int x = coordinates.Item1;
                int y = coordinates.Item2;

                int CellValue = _gameLogic.Positions[x, y];

                btn.BackColor = Color.LightGray;

                if (CellValue == 10)
                {
                    btn.Image = Properties.Resources.mine;
                }
                else if (CellValue == 0)
                {
                    btn.Text = "";
                }
                else
                {
                    btn.Text = CellValue.ToString();
                    btn.ForeColor = _cellColor.GetMineCountColor(CellValue);
                }
            }
        }
    }
}
