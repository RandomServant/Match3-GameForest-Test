﻿namespace Match3.Visual
{
    partial class GameOverWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.GameOveOkey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over!";
            // 
            // GameOveOkey
            // 
            this.GameOveOkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GameOveOkey.Location = new System.Drawing.Point(150, 90);
            this.GameOveOkey.Name = "GameOveOkey";
            this.GameOveOkey.Size = new System.Drawing.Size(100, 35);
            this.GameOveOkey.TabIndex = 1;
            this.GameOveOkey.Text = "OK";
            this.GameOveOkey.UseVisualStyleBackColor = true;
            this.GameOveOkey.Click += new System.EventHandler(this.GameOveOkey_Click);
            // 
            // GameOverWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.GameOveOkey);
            this.Controls.Add(this.label1);
            this.Name = "GameOverWindow";
            this.Text = "Match3 GameOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GameOveOkey;
    }
}