namespace Minesweeper_WinForms
{
    public partial class Form1 : Form
    {
        byte[,] positions = new byte[15, 15];
        Button[,] buttonList = new Button[15, 15];
        public Form1()
        {
            InitializeComponent();
            GenerateBombs();
            GeneratePositionValue();
            GenerateButtons();
        }

        Random rng = new Random();

        private void GenerateBombs()
        {
            int bombs = 0;

            while (bombs < 30)
            {
                int x = rng.Next(0, 14);
                int y = rng.Next(0, 14);

                if (positions[x, y] == 0)
                {
                    positions[x, y] = 10;
                    bombs++;
                }
            }
        }

        private void GeneratePositionValue()
        {
            //2 loopy skrz vsechny pozice
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    //pro miny nepocitam okolni miny
                    if (positions[x, y] == 10)
                        continue;

                    byte bombCounts = 0;

                    //2 loopy pocitajici kolik bomb je na kazdem sousedovi
                    for (int counterX = -1; counterX < 2; counterX++)
                    {
                        int checkerX = x + counterX;

                        for (int counterY = -1; counterY < 2; counterY++)
                        {
                            int checkerY = y + counterY;

                            //out of bound, cili krajni, pro ktere nema smysl pocitat
                            if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
                                continue;

                            //nasel jsem jako souseda bunku ve ktere jsem, nema smysl pocitat
                            if (checkerY == y && checkerX == x)
                                continue;

                            if (positions[checkerY, checkerX] == 10)
                                bombCounts++;
                        }
                    }

                    //prazdne, nebo zadna mina v okoli
                    if (bombCounts == 0)
                        positions[x, y] = 20;
                    else
                        positions[x, y] = bombCounts;
                }
            }
        }

        private void GenerateButtons()
        {
            int xLoc = 3;
            int yLoc = 6;
            for (int x = 0; x < 15; ++x)
            {
                for (int y = 0; y < 15; ++y)
                {
                    Button btn = new Button();
                    btn.Parent = pnlBody;
                    btn.Location = new Point(xLoc, yLoc);
                    btn.Size = new Size(30, 30);
                    btn.Tag = $"{x},{y}";
                    btn.Click += BtnClick;
                    btn.MouseUp += BtnMouseUp;
                    xLoc += 30;
                    buttonList[x, y] = btn;
                }

                yLoc += 30;
                xLoc = 3;
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));

            byte value = positions[x, y];

            //kdyz je bomba tady
            if (value == 10)
            {
                btn.Image = Properties.Resources.mine1;

                MessageBox.Show("Game Over");
                pnlBody.Enabled = false;
            }

            //kdyz je to tady prazdny
            else if (value == 20)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
                btn.FlatAppearance.BorderSize = 1;
                btn.Enabled = false;

                OpenAdjacentEmptyFile(btn);

                points++;
            }

            //kdyz to ma sousedni bomby
            else
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = SystemColors.ControlDark;
                btn.FlatAppearance.MouseDownBackColor = btn.BackColor;
                btn.FlatAppearance.MouseOverBackColor = btn.BackColor;

                btn.Text = positions[x, y].ToString();
                points++;
            }

            btn.Click -= BtnClick;
            txtScore.Text = points.ToString();

        }

        private void OpenAdjacentEmptyFile(Button btn)
        {
            int x = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(0));
            int y = Convert.ToInt32(btn.Tag.ToString().Split(',').GetValue(1));

            List<Button> emptyButtons = new List<Button>();

            for (int counterX = -1; counterX < 2; counterX++)
            {
                int checkerX = x + counterX;

                for (int counterY = -1; counterY < 2; counterY++)
                {
                    int checkerY = y + counterY;

                    //out of bound, cili krajni, pro ktere nema smysl pocitat
                    if (checkerX == -1 || checkerY == -1 || checkerX > 14 || checkerY > 14)
                        continue;

                    //nasel jsem jako souseda bunku ve ktere jsem, nema smysl pocitat
                    if (checkerY == y && checkerX == x)
                        continue;

                    Button btnAdjacent = buttonList[checkerX, checkerY];

                    int xAdjacent = Convert.ToInt32(btnAdjacent.Tag.ToString().Split(',').GetValue(0));
                    int yAdjacent = Convert.ToInt32(btnAdjacent.Tag.ToString().Split(',').GetValue(1));

                    byte value = positions[xAdjacent, yAdjacent];

                    //zjisti jestli btnAdjacent uz byl otevren nebo jestli na nej bylo kliknuto
                    if (value == 20)
                    {
                        if (btnAdjacent.FlatStyle != FlatStyle.Flat)
                        {
                            btnAdjacent.FlatStyle = FlatStyle.Flat;
                            btnAdjacent.FlatAppearance.BorderSize = 1;
                            btnAdjacent.FlatAppearance.BorderColor = SystemColors.ControlDark;
                            btnAdjacent.Enabled = false;
                            emptyButtons.Add(btnAdjacent);
                            points++;
                        }

                    }

                    else if (value != 10)
                    {
                        btnAdjacent.PerformClick();
                    }
                }
            }

            foreach (var btnEmpty in emptyButtons)
            {
                OpenAdjacentEmptyFile(btnEmpty);
            }

            txtScore.Text = points.ToString();
        }

        int flag = 30;
        int points = 0;

        private void BtnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button btn = (Button)sender;

                if (btn.Image == null)
                {
                    btn.Image = Properties.Resources.red_flag1;
                    btn.Click -= BtnClick;
                    flag--;
                }
                else
                {
                    btn.Image = null;
                    btn.Click += BtnClick;
                    flag++;
                }
                txtFlag.Text = flag.ToString();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            points = 0;
            flag = 30;

            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    buttonList[x, y].Dispose();
                }
            }

            pnlBody.Controls.Clear();
            pnlBody.Enabled = true;
            buttonList = new Button[15, 15];
            positions = new byte[15, 15];

            GenerateBombs();
            GeneratePositionValue();
            GenerateButtons();
        }
    }
}
