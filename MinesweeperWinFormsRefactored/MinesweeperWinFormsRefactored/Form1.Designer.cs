namespace MinesweeperWinFormsRefactored
{
    partial class MinesweeperMainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBeginner = new Button();
            btnIntermediate = new Button();
            btnExpert = new Button();
            txtFlags = new TextBox();
            txtScore = new TextBox();
            label1 = new Label();
            labelScore = new Label();
            panelGameField = new Panel();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnBeginner
            // 
            btnBeginner.Location = new Point(12, 12);
            btnBeginner.Name = "btnBeginner";
            btnBeginner.Size = new Size(120, 40);
            btnBeginner.TabIndex = 0;
            btnBeginner.Text = "Beginner";
            btnBeginner.UseVisualStyleBackColor = true;
            btnBeginner.Click += btnBeginner_Click;
            // 
            // btnIntermediate
            // 
            btnIntermediate.Location = new Point(138, 12);
            btnIntermediate.Name = "btnIntermediate";
            btnIntermediate.Size = new Size(120, 40);
            btnIntermediate.TabIndex = 1;
            btnIntermediate.Text = "Intermediate";
            btnIntermediate.UseVisualStyleBackColor = true;
            btnIntermediate.Click += btnIntermediate_Click;
            // 
            // btnExpert
            // 
            btnExpert.Location = new Point(264, 12);
            btnExpert.Name = "btnExpert";
            btnExpert.Size = new Size(120, 40);
            btnExpert.TabIndex = 2;
            btnExpert.Text = "Expert";
            btnExpert.UseVisualStyleBackColor = true;
            btnExpert.Click += btnExpert_Click;
            // 
            // txtFlags
            // 
            txtFlags.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtFlags.Location = new Point(12, 79);
            txtFlags.Name = "txtFlags";
            txtFlags.Size = new Size(54, 32);
            txtFlags.TabIndex = 3;
            // 
            // txtScore
            // 
            txtScore.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            txtScore.Location = new Point(858, 79);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(54, 32);
            txtScore.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 82);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 5;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Location = new Point(803, 82);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(49, 20);
            labelScore.TabIndex = 6;
            labelScore.Text = "Score:";
            // 
            // panelGameField
            // 
            panelGameField.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            panelGameField.Location = new Point(12, 112);
            panelGameField.Name = "panelGameField";
            panelGameField.Size = new Size(900, 479);
            panelGameField.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 2);
            label2.Name = "label2";
            label2.Size = new Size(297, 40);
            label2.TabIndex = 8;
            label2.Text = "dodelat:\r\n1) odkryt vsechno po tom co kliknu na minu";
            // 
            // MinesweeperMainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 603);
            Controls.Add(label2);
            Controls.Add(panelGameField);
            Controls.Add(labelScore);
            Controls.Add(label1);
            Controls.Add(txtScore);
            Controls.Add(txtFlags);
            Controls.Add(btnExpert);
            Controls.Add(btnIntermediate);
            Controls.Add(btnBeginner);
            Name = "MinesweeperMainWindow";
            Text = "Minesweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBeginner;
        private Button btnIntermediate;
        private Button btnExpert;
        private TextBox txtFlags;
        private TextBox txtScore;
        private Label label1;
        private Label labelScore;
        private Panel panelGameField;
        private Label label2;
    }
}
