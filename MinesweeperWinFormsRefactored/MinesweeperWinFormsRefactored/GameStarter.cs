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
        private TextBoxHandler _flagsHandler;

        public GameStarter(GameLogic gameLogic, ButtonGenerator buttonGenerator, AutoRevealEmpty autoRevealEmpty, TextBoxHandler flagsHandler)
        {
            _gameLogic = gameLogic;
            _buttonGenerator = buttonGenerator;
            _autoRevealEmpty = autoRevealEmpty;
            _flagsHandler = flagsHandler;
        }

        public void StartGame(int columns, int rows, int mines)
        {
            _gameLogic.ColumnsCount = columns;
            _gameLogic.RowsCount = rows;
            _gameLogic.MinesCount = mines;

            _autoRevealEmpty.Reset();
            _gameLogic.ResetRevealedCellsCount();

            _gameLogic.InitializeBoardDimensions();
            _gameLogic.GenerateBombs();
            _gameLogic.CalculateAdjacentMines();

            _flagsHandler.SetValue(mines);

            _buttonGenerator.GenerateButtons(columns, rows);
        }
    }
}
