using System.Diagnostics;

namespace MinesweeperWinFormsRefactored
{
    public partial class MinesweeperMainWindow : Form
    {
        //creating variables
        GameStarter gameStarter;
        Timer timer;
        Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Constructor for the MinesweeperMainWindow class.
        /// Initializes all components and sets up dependencies for game logic and UI.
        /// </summary>
        public MinesweeperMainWindow()
        {
            InitializeComponent();

            ButtonGenerator buttonGenerator;
            AutoRevealEmpty autoRevealEmpty;
            GameLogic gameLogic;
            RevealAllCells revealAllCells;

            gameLogic = new GameLogic();
            timer = new Timer(stopwatch, timerDesign);
            revealAllCells = new RevealAllCells(panelGameField, new CellColor(), gameLogic);
            autoRevealEmpty = new AutoRevealEmpty(gameLogic, panelGameField, new TextBoxHandler(txtScore), new CellColor());
            buttonGenerator = new ButtonGenerator(panelGameField, gameLogic, autoRevealEmpty, new TextBoxHandler(txtFlags), new TextBoxHandler(txtScore), new CellColor(), revealAllCells, timer);
            gameStarter = new GameStarter(gameLogic, buttonGenerator, autoRevealEmpty, new TextBoxHandler(txtFlags), timer);
        }

        /// <summary>
        /// Handles the 'Beginner' button click event.
        /// Starts a beginner-level game (9x9 grid with 10 mines).
        /// </summary>
        private void btnBeginner_Click(object sender, EventArgs e)
        {
            gameStarter.StartGame(9, 9, 10);
            timer.TimerStart();
        }

        /// <summary>
        /// Handles the 'Intermediate' button click event.
        /// Starts a beginner-level game (16x16 grid with 40 mines).
        /// </summary>
        private void btnIntermediate_Click(object sender, EventArgs e)
        {
            gameStarter.StartGame(16, 16, 40);
            timer.TimerStart();
        }

        /// <summary>
        /// Handles the 'Expert' button click event.
        /// Starts a beginner-level game (30x16 grid with 99 mines).
        /// </summary>
        private void btnExpert_Click(object sender, EventArgs e)
        {
            gameStarter.StartGame(30, 16, 99);
            timer.TimerStart();
        }

        /// <summary>
        /// Method for updating time on a screen at each tick of the timer.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                labelTime.Text = $"{timer.GetElapsedTime().Minutes:D2}:{timer.GetElapsedTime().Seconds:D2}";
            }
        }
    }
}
