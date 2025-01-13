using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperWinFormsRefactored
{
    /// <summary>
    /// Responsible for initializing and starting a new game of Minesweeper.
    /// Coordinates the setup of the game board, game logic, and UI elements.
    /// </summary>
    internal class GameStarter
    {
        private GameLogic _gameLogic;
        private ButtonGenerator _buttonGenerator;
        private AutoRevealEmpty _autoRevealEmpty;
        private TextBoxHandler _flagsHandler;
        private TextBoxHandler _scoreHandler;
        private Timer _timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStarter"/> class.
        /// </summary>
        /// <param name="gameLogic">Handles the game's core logic (board dimensions, bomb placement, etc.).</param>
        /// <param name="buttonGenerator">Generates the UI buttons representing the game board.</param>
        /// <param name="autoRevealEmpty">Handles automatic revealing of empty cells.</param>
        /// <param name="flagsHandler">Manages the display and count of remaining flags.</param>
        /// <param name="scoreHandler">Manages the display and count of already successfully revealed cells.</param>
        /// <param name="timer">Handles the game timer.</param>
        public GameStarter(GameLogic gameLogic, ButtonGenerator buttonGenerator, AutoRevealEmpty autoRevealEmpty, TextBoxHandler flagsHandler, TextBoxHandler scoreHandler, Timer timer)
        {
            _gameLogic = gameLogic;
            _buttonGenerator = buttonGenerator;
            _autoRevealEmpty = autoRevealEmpty;
            _flagsHandler = flagsHandler;
            _scoreHandler = scoreHandler;
            _timer = timer;
        }

        /// <summary>
        /// Starts a new Minesweeper game by setting up the board, initializing bombs, and starting the timer.
        /// </summary>
        /// <param name="columns">Number of columns for the game board.</param>
        /// <param name="rows">Number of rows for the game board.</param>
        /// <param name="mines">Number of bombs to be placed on the game board.</param>
        public void StartGame(int columns, int rows, int mines)
        {
            //set board dimensions and # of mines
            _gameLogic.ColumnsCount = columns;
            _gameLogic.RowsCount = rows;
            _gameLogic.MinesCount = mines;

            //reset helper classes for a new game
            _autoRevealEmpty.Reset();
            _gameLogic.ResetRevealedCellsCount();
            _scoreHandler.ResetValue();

            //initialize and set up a new game board
            _gameLogic.InitializeBoardDimensions();
            _gameLogic.GenerateBombs();
            _gameLogic.CalculateAdjacentMines();

            //set the initial flag count for to the number of mines
            _flagsHandler.SetValue(mines);

            //generate UI buttons for the game board
            _buttonGenerator.GenerateButtons(columns, rows);

            //start the game timer
            _timer.TimerStart();
        }
    }
}
