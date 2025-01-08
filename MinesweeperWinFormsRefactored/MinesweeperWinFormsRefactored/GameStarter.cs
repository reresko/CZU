using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    internal class GameStarter
    {
        private GameLogic _gameLogic;
        private ButtonGenerator _buttonGenerator;
        private AutoRevealEmpty _autoRevealEmpty;

        public GameStarter(GameLogic gameLogic, ButtonGenerator buttonGenerator, AutoRevealEmpty autoRevealEmpty)
        {
            _gameLogic = gameLogic;
            _buttonGenerator = buttonGenerator;
            _autoRevealEmpty = autoRevealEmpty;
        }

        public void StartGame(int columns, int rows, int mines)
        {
            _gameLogic.ColumnsCount = columns;
            _gameLogic.RowsCount = rows;
            _gameLogic.MinesCount = mines;

            _gameLogic.InitializeBoardDimensions();
            _gameLogic.GenerateBombs();
            _gameLogic.CalculateAdjacentMines();

            _buttonGenerator.GenerateButtons(columns, rows);

            _autoRevealEmpty.Reset();
            _gameLogic.ResetRevealedCellsCount();
        }
    }
}
