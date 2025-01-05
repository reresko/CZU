namespace Minesweeper_WinForms
{
    partial class Form1
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
            pnlBody = new Panel();
            Restart = new Button();
            txtFlag = new TextBox();
            txtScore = new TextBox();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.BackColor = SystemColors.Control;
            pnlBody.Location = new Point(41, 121);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(618, 463);
            pnlBody.TabIndex = 10;
            // 
            // Restart
            // 
            Restart.Dock = DockStyle.Top;
            Restart.Location = new Point(0, 0);
            Restart.Name = "Restart";
            Restart.Size = new Size(714, 30);
            Restart.TabIndex = 1;
            Restart.Text = "Restart";
            Restart.UseVisualStyleBackColor = true;
            Restart.Click += btnRestart_Click;
            // 
            // txtFlag
            // 
            txtFlag.Dock = DockStyle.Top;
            txtFlag.Location = new Point(0, 30);
            txtFlag.Name = "txtFlag";
            txtFlag.Size = new Size(714, 27);
            txtFlag.TabIndex = 2;
            // 
            // txtScore
            // 
            txtScore.Dock = DockStyle.Top;
            txtScore.Location = new Point(0, 57);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(714, 27);
            txtScore.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 681);
            Controls.Add(txtScore);
            Controls.Add(txtFlag);
            Controls.Add(Restart);
            Controls.Add(pnlBody);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBody;
        private Button Restart;
        private TextBox txtFlag;
        private TextBox txtScore;
    }
}
