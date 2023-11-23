using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3
{
    public partial class MenuWindow : Form
    {
        public static MenuWindow Instance;

        public MenuWindow()
        {
            InitializeComponent();

            Instance = this;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameWindow GameForm = new GameWindow();
            GameForm.Show();
            this.Hide();
        }
    }
}
