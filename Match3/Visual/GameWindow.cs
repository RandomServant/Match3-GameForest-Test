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
        private Color _selectColor = Color.Aqua;

        private readonly Game _game;

        private readonly Dictionary<Vector2, PictureBox> _images;

        public GameWindow()
        {
            InitializeComponent();

            this.Size = new Size(_cellGridSize * (_gridSize + 1), 
                _cellGridSize * (_gridSize + 1) + SystemInformation.CaptionHeight);

            _game = new Game(this, _gridSize);

            _images = new Dictionary<Vector2, PictureBox>();

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
                    Vector2 position = new Vector2(i, j);

                    var picture = new PictureBox
                    {
                        Size = new Size(_cellGridSize, _cellGridSize),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = _game.GetElement(position).GetIconImage(),
                        Tag = position.ToString()
                    };
                    picture.Click += GridClick;

                    gridLayout.Controls.Add(picture, i, j);
                    _images[position] = picture;
                }
            }
        }
        private void GridClick(object sender, EventArgs e)
        {
            var element = (PictureBox)sender;

            Vector2 id = Vector2.StringToVector2(element.Tag);
            _game.SelectElement(id);
        }

        public void MarkSelected(Vector2 id)
        {
            _images[id].BackColor = _selectColor;
        }

        public void MarkDeselected(Vector2 id)
        {
            _images[id].BackColor = this.BackColor;
        }
    }
}
