using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3
{
    public partial class GameWindow : Form
    {
        private const int _gridSize = 8;
        private const int _cellGridSize = 65;

        private readonly Game _game;

        private readonly Dictionary<Vector2, Image> _images;

        public GameWindow()
        {
            InitializeComponent();

            this.Size = new Size(_cellGridSize * (_gridSize + 1), 
                _cellGridSize * (_gridSize + 1) + SystemInformation.CaptionHeight);

            _game = new Game(this, _gridSize); 

            CreateGridLayout();
        }

        private void CreateGridLayout()
        {
            TableLayoutPanel gridLayout = new TableLayoutPanel();

            gridLayout.RowCount = _gridSize;
            gridLayout.ColumnCount = _gridSize;

            gridLayout.Size = new Size(_cellGridSize * (_gridSize + 1), _cellGridSize * (_gridSize + 1));

            this.Controls.Add(gridLayout);

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    Vector2 positon = new Vector2(i, j);

                    var picture = new PictureBox
                    {
                        Size = new Size(_cellGridSize, _cellGridSize),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Visual\Images\Red.png")),
                        Tag = positon.ToString()
                    };
                    picture.Click += GridClick;

                    gridLayout.Controls.Add(picture, i, j);
                }
            }
        }
        private void GridClick(object sender, EventArgs e)
        {
            var element = (PictureBox)sender;

            Vector2 id = Vector2.StringToVector2(element.Tag);
            _game.SelectElement(id);
        }
    }
}
