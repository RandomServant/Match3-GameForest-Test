using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3.Visual
{
    public partial class GameOverWindow : Form
    {
        public GameOverWindow()
        {
            InitializeComponent();
        }

        private void GameOveOkey_Click(object sender, EventArgs e)
        {
            MenuWindow.Instance.Show();
            GameWindow.Instance.Close();
            this.Close();
        }
    }
}
