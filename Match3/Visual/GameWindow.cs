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
    public partial class GameWindow : Form
    {
        private const int _gridSize = 8;

        private readonly Game _game;

        public GameWindow()
        {
            InitializeComponent();

            _game = new Game(this, _gridSize); 

            CreateGridLayout();
        }

        private void CreateGridLayout()
        {
            TableLayoutPanel gridLayout = new TableLayoutPanel();

            gridLayout.RowCount = _gridSize;
            gridLayout.ColumnCount = _gridSize;

            for(int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    gridLayout.Controls.Add(new PictureBox());
                }
            }

            this.Controls.Add(gridLayout);
        }
    }
}
