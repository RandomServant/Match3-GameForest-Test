﻿namespace Match3
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
            this.ScoreText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TimerText
            // 
            this.TimerText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimerText.AutoSize = true;
            this.TimerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.TimerText.Location = new System.Drawing.Point(706, 9);
            this.TimerText.Name = "TimerText";
            this.TimerText.Size = new System.Drawing.Size(64, 46);
            this.TimerText.TabIndex = 0;
            this.TimerText.Text = "60";
            this.TimerText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ScoreText
            // 
            this.ScoreText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScoreText.BackColor = System.Drawing.SystemColors.Control;
            this.ScoreText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScoreText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ScoreText.HideSelection = false;
            this.ScoreText.Location = new System.Drawing.Point(670, 58);
            this.ScoreText.Name = "ScoreText";
            this.ScoreText.Size = new System.Drawing.Size(100, 46);
            this.ScoreText.TabIndex = 2;
            this.ScoreText.Text = "0";
            this.ScoreText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TimerText;
        private System.Windows.Forms.TextBox ScoreText;
    }
}