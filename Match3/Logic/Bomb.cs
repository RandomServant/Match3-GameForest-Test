using Match3.Visual;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3.Logic
{
    public class Bomb : IElement
    {
        public Animator Animator { get; set; }
        public ElementType Type { get; set; }
        public Vector2 Position { get; set; }

        public bool IsNull { get; private set; }

        public Bomb(IElement element)
        {
            Position = element.Position;
            Type = element.Type;
            Animator = new Animator();
        }

        public void Destroy(IElement[,] elementList)
        {
            if (IsNull)
                return;

            ScoreCounter.AddScore();
            IsNull = true;
            ActivateBonus(elementList);
        }

        private void ActivateBonus(IElement[,] list)
        {
            for(int i = -1; i <= 1; i++)
            {
                if (Position.X + i < 0 || Position.X + i >= GameWindow.GridSize)
                    continue;

                for (int j = -1; j <= 1; j++) 
                {
                    if (Position.Y + j < 0 || Position.Y + j >= GameWindow.GridSize)
                        continue;

                    list[Position.X + i, Position.Y + j].Destroy(list);
                }
            }
        }

        public Image GetIconImage()
        {
            string path;

            switch (Type)
            {
                case ElementType.Red:
                    path = @"..\..\Visual\Images\RedBomb.png";
                    break;
                case ElementType.Green:
                    path = @"..\..\Visual\Images\GreenBomb.png";
                    break;
                case ElementType.Blue:
                    path = @"..\..\Visual\Images\BlueBomb.png";
                    break;
                case ElementType.Yellow:
                    path = @"..\..\Visual\Images\YellowBomb.png";
                    break;
                default:
                    path = @"..\..\Visual\Images\OrangeBomb.png";
                    break;
            }
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            return Image.FromFile(path);
        }
    }
}
