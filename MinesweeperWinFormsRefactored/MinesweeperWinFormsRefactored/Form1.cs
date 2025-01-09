namespace MinesweeperWinFormsRefactored
{
    public partial class MinesweeperMainWindow : Form
    {
        GameStarter gameStarter;

        public MinesweeperMainWindow()
        {
            InitializeComponent();

            ButtonGenerator buttonGenerator;
            AutoRevealEmpty autoRevealEmpty;
            GameLogic gameLogic;
            RevealAllCells revealAllCells;

            gameLogic = new GameLogic();
            revealAllCells = new RevealAllCells(panelGameField, new CellColor(), gameLogic);
            autoRevealEmpty = new AutoRevealEmpty(gameLogic, panelGameField, new TextBoxHandler(txtScore), new CellColor());
            buttonGenerator = new ButtonGenerator(panelGameField, gameLogic, autoRevealEmpty, new TextBoxHandler(txtFlags), new TextBoxHandler(txtScore), new CellColor(), revealAllCells);
            gameStarter = new GameStarter(gameLogic, buttonGenerator, autoRevealEmpty, new TextBoxHandler(txtFlags));
        }

        private void btnBeginner_Click(object sender, EventArgs e)
        {
            gameStarter.StartGame(9, 9, 10);
        }

        private void btnIntermediate_Click(object sender, EventArgs e)
        {
            gameStarter.StartGame(16, 16, 40);
        }

        private void btnExpert_Click(object sender, EventArgs e)
        {
            gameStarter.StartGame(30, 16, 99);
        }
    }
}
