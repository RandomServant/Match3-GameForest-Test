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
    internal class HorizontalLine : IElement
    {
        public Animator Animator { get; set; }
        public ElementType Type { get; set; }
        public Vector2 Position { get; set; }

        public bool IsNull { get; private set; }

        public HorizontalLine(IElement element)
        {
            Position = element.Position;
            Type = element.Type;
            Animator = new Animator();
        }

        public void Destroy(IElement[,] elementList)
        {
            if (IsNull) return;

            ScoreCounter.AddScore();
            IsNull = true;
            ActivateBonus(elementList);
        }
        private void ActivateBonus(IElement[,] elementList)
        {
            for (int i = 0; i < GameWindow.GridSize; i++)
            {
                elementList[i, Position.Y].Destroy(elementList);
            }
        }

        public Image GetIconImage()
        {
            string path;

            switch (Type)
            {
                case ElementType.Red:
                    path = @"..\..\Visual\Images\RedHorizontal.png";
                    break;
                case ElementType.Green:
                    path = @"..\..\Visual\Images\GreenHorizontal.png";
                    break;
                case ElementType.Blue:
                    path = @"..\..\Visual\Images\BlueHorizontal.png";
                    break;
                case ElementType.Yellow:
                    path = @"..\..\Visual\Images\YellowHorizontal.png";
                    break;
                default:
                    path = @"..\..\Visual\Images\OrangeHorizontal.png";
                    break;
            }
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            return Image.FromFile(path);
        }
    }
}
