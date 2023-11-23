namespace Match3
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TimerText = new System.Windows.Forms.Label();
            this.ScoreText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimerText
            // 
            this.TimerText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.TimerText.Location = new System.Drawing.Point(593, 9);
            this.TimerText.Name = "TimerText";
            this.TimerText.Size = new System.Drawing.Size(177, 46);
            this.TimerText.TabIndex = 0;
            this.TimerText.Text = "60";
            this.TimerText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScoreText
            // 
            this.ScoreText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ScoreText.Location = new System.Drawing.Point(593, 55);
            this.ScoreText.Name = "ScoreText";
            this.ScoreText.Size = new System.Drawing.Size(177, 46);
            this.ScoreText.TabIndex = 3;
            this.ScoreText.Text = "0";
            this.ScoreText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.ScoreText);
            this.Controls.Add(this.TimerText);
            this.Name = "GameWindow";
            this.Text = "Match3 Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TimerText;
        private System.Windows.Forms.Label ScoreText;
    }
}