using Match3.Visual;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Match3
{
    public partial class GameWindow : Form
    {
        public const int GridSize = 8;
        public const int CellGridSize = 65;
        private const int _gameDataPanelWidth = 150;
        private Color _selectColor = Color.Aqua;

        private readonly Game _game;

        private readonly Dictionary<Vector2, Button> _buttons;
        private readonly Dictionary<Vector2, PictureBox> _images;

        public bool IsWindowInitialized = false;

        public GameWindow()
        {
            InitializeComponent();

            this.Size = new Size(CellGridSize * (GridSize + 1) + _gameDataPanelWidth,
                CellGridSize * (GridSize + 1) + SystemInformation.CaptionHeight);

            _game = new Game(this, GridSize);

            _buttons = new Dictionary<Vector2, Button>();
            _images = new Dictionary<Vector2, PictureBox>();

            CreateGridLayout();
            _game.Initialize();
            UpdateVisual();
            _game.InitializeTimer();
        }

        public void UpdateVisual()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Vector2 position = new Vector2(i, j);
                    if (Game.IsInitialized && IsWindowInitialized)
                        this.Controls.Remove(_images[position]);

                    IElement element = _game.GetElement(position);
                    if (element.IsNull)
                        continue;

                    PictureBox image = new PictureBox
                    {
                        Image = element.GetIconImage(),
                        Size = new Size(CellGridSize, CellGridSize),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Location = _buttons[position].Location,
                        Enabled = false
                    };

                    this.Controls.Add(image);
                    image.BringToFront();
                    _images[position] = image;
                }
            }
            IsWindowInitialized = true;
        }

        private void CreateGridLayout()
        {
            TableLayoutPanel gridLayout = new TableLayoutPanel
            {
                RowCount = GridSize,
                ColumnCount = GridSize,

                Size = new Size(CellGridSize * (GridSize + 1), CellGridSize * (GridSize + 1))
            };

            this.Controls.Add(gridLayout);

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Vector2 position = new Vector2(i, j);

                    Button button = new Button
                    {
                        Size = new Size(CellGridSize, CellGridSize),
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

        public void SwapAnimation(IElement first, IElement second)
        {
            PictureBox firstElement = _images[first.Position];
            PictureBox secondElement = _images[second.Position];

            first.Animator.MoveAnimation(firstElement, secondElement.Location);
            second.Animator.MoveAnimation(secondElement, firstElement.Location);
        }

        public void PushDownAnimation(List<Vector2> moveFrom, List<Vector2> moveTo)
        {
            for (int i = 0; i < moveFrom.Count; i++)
            {
                PictureBox element = _images[moveFrom[i]];
                _game.GetElement(moveFrom[i]).Animator.MoveAnimation(element, _buttons[moveTo[i]].Location);
            }
        }

        public void DestroyAnimation()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Vector2 position = new Vector2(i, j);
                    IElement element = _game.GetElement(position);

                    if (element.IsNull)
                    {
                        element.Animator.DestroyAnimation(_images[position]);
                    }
                }
            }
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
        public void UpdateScoreText(string score)
        {
            ScoreText.Text = score;
        }

        public void GameOver()
        {
            GameOverWindow gameOverWindow = new GameOverWindow();
            gameOverWindow.Show();
            this.Close();
        }
    }
}
