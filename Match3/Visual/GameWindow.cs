using Match3.Logic;
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

        private readonly Dictionary<Vector2, Button> _buttons;
        private readonly Dictionary<Vector2, PictureBox> _images;

        private bool _isWindowInitialized = false;

        public GameWindow()
        {
            InitializeComponent();

            this.Size = new Size(_cellGridSize * (_gridSize + 1), 
                _cellGridSize * (_gridSize + 1) + SystemInformation.CaptionHeight);

            _game = new Game(this, _gridSize);

            _buttons = new Dictionary<Vector2, Button>();
            _images = new Dictionary<Vector2, PictureBox>();

            CreateGridLayout();
            _game.Initialize();
            UpdateVisual();
            _game.InitializeTimer();
        }

        public void UpdateVisual()
        {
            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    Vector2 position = new Vector2(i, j);
                    if (Game.IsInitialized && _isWindowInitialized)
                        this.Controls.Remove(_images[position]);

                    IElement element = _game.GetElement(position);
                    if (element.IsNull)
                        continue;

                    PictureBox image = new PictureBox
                    {
                        Image = element.GetIconImage(),
                        Size = new Size(_cellGridSize, _cellGridSize),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = _buttons[position].Location,
                        Enabled = false
                    };

                    this.Controls.Add(image);
                    image.BringToFront();
                    _images[position] = image;
                }
            }
            _isWindowInitialized = true;
        }

        private void CreateGridLayout()
        {
            TableLayoutPanel gridLayout = new TableLayoutPanel
            {
                RowCount = _gridSize,
                ColumnCount = _gridSize,

                Size = new Size(_cellGridSize * (_gridSize + 1), _cellGridSize * (_gridSize + 1))
            };

            this.Controls.Add(gridLayout);

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    Vector2 position = new Vector2(i, j);

                    Button button = new Button
                    {
                        Size = new Size(_cellGridSize, _cellGridSize),
                        Tag = position.ToString(),
                    };
                    button.Click += GridClick;

                    gridLayout.Controls.Add(button, i, j);
                    _buttons[position] = button;
                }
            }
        }
        private void GridClick(object sender, EventArgs e)
        {
            Button element = (Button)sender;

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

        public void UpdateTimerText(string time)
        {
            TimerText.Text = time;
        }
    }
}
