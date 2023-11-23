using Match3.Logic;
using Match3.Visual;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3
{
    public partial class GameWindow : Form
    {
        public static GameWindow Instance;

        public const int GridSize = 8;
        public const int CellGridSize = 65;
        private const int _gameDataPanelWidth = 150;
        private Color _selectColor = Color.Aqua;

        private readonly Game _game;

        private TableLayoutPanel _gridLayout;
        private readonly Dictionary<Vector2, Button> _buttons;
        private readonly Dictionary<Vector2, PictureBox> _images;

        public bool IsWindowInitialized = false;

        public GameWindow()
        {
            InitializeComponent();

            Instance = this;

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
            _gridLayout = new TableLayoutPanel
            {
                RowCount = GridSize,
                ColumnCount = GridSize,

                Size = new Size(CellGridSize * (GridSize + 1), CellGridSize * (GridSize + 1))
            };

            this.Controls.Add(_gridLayout);

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

                    _gridLayout.Controls.Add(button, i, j);
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

            first.Animator.MoveAnimation(firstElement, secondElement.Location, Animator.MoveAnimationDelayInMilliseconds);
            second.Animator.MoveAnimation(secondElement, firstElement.Location, Animator.MoveAnimationDelayInMilliseconds);
        }

        public void PushDownAnimation(List<Vector2> moveFrom, List<Vector2> moveTo)
        {
            for (int i = 0; i < moveFrom.Count; i++)
            {
                PictureBox element = _images[moveFrom[i]];
                _game.GetElement(moveFrom[i]).Animator.MoveAnimation(element, 
                    _buttons[moveTo[i]].Location, Animator.PushDownDelayInMilliseconds);
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
        public void DestroyersFlyAnimation(IElement bonus)
        {
            Point targetPosition;
            Point oppositeЕargetPosition;

            if (bonus is HorizontalLine)
            {
                targetPosition = new Point(_gridLayout.Width, _images[bonus.Position].Location.Y);
                oppositeЕargetPosition = new Point(-CellGridSize, _images[bonus.Position].Location.Y);
            }
            else if (bonus is VerticalLine)
            {
                targetPosition = new Point(_images[bonus.Position].Location.X, _gridLayout.Height);
                oppositeЕargetPosition = new Point(_images[bonus.Position].Location.X, -CellGridSize);
            }
            else
                return;

            Destroyer firstDestroyer = new Destroyer(_images[bonus.Position].Location);
            Destroyer secondDestroyer = new Destroyer(_images[bonus.Position].Location);

            this.Controls.Add(firstDestroyer);
            this.Controls.Add(secondDestroyer);

            firstDestroyer.BringToFront();
            secondDestroyer.BringToFront();

            firstDestroyer.Animator.MoveAnimation(firstDestroyer, targetPosition, Animator.LineDestroyDelay);
            secondDestroyer.Animator.MoveAnimation(secondDestroyer, oppositeЕargetPosition, Animator.LineDestroyDelay);

            DestroyersDestroy(firstDestroyer);
            DestroyersDestroy(secondDestroyer);
        }

        private async void DestroyersDestroy(Destroyer destroyer)
        {
            await Task.Delay(Animator.LineDestroyDelay);
            this.Controls.Remove(destroyer);
        }

        public void MarkSelected(Vector2 position)
        {
            _images[position].BackColor = _selectColor;
        }

        public void MarkDeselected(Vector2 position)
        {
            _images[position].BackColor = this.BackColor;
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
            _gridLayout.Enabled = false;
            gameOverWindow.Show();
        }
    }
}
