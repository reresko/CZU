namespace MinesweeperWinFormsRefactored
{
    public partial class MinesweeperMainWindow : Form
    {
        GameStarter gameStarter;
        public MinesweeperMainWindow()
        {
            InitializeComponent();

            GameLogic gameLogic = new GameLogic();

            //ButtonGenerator buttonGenerator;
            AutoRevealEmpty autoRevealEmpty = new AutoRevealEmpty(gameLogic, panelGameField);
            ButtonGenerator buttonGenerator;
            buttonGenerator = new ButtonGenerator(panelGameField, gameLogic, autoRevealEmpty);
            autoRevealEmpty._buttonGenerator = buttonGenerator;
            //autoRevealEmpty = new AutoRevealEmpty(gameLogic, panelGameField, buttonGenerator);
            gameStarter = new GameStarter(gameLogic, buttonGenerator, autoRevealEmpty);
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
