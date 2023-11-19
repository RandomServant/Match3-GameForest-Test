using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3.Logic
{
    public class VerticalLine : IElement
    {
        public ElementType Type { get; set; }
        public Vector2 Position { get; set; }

        public bool IsNull { get; private set; }

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
                elementList[Position.X, i].Destroy(elementList);
            }
        }

        public Image GetIconImage()
        {
            string path;

            switch (Type)
            {
                case ElementType.Red:
                    path = @"..\..\Visual\Images\Red.png";
                    break;
                case ElementType.Green:
                    path = @"..\..\Visual\Images\Green.png";
                    break;
                case ElementType.Blue:
                    path = @"..\..\Visual\Images\Blue.png";
                    break;
                case ElementType.Yellow:
                    path = @"..\..\Visual\Images\Yellow.png";
                    break;
                default:
                    path = @"..\..\Visual\Images\Orange.png";
                    break;
            }
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            return Image.FromFile(path);
        }
    }
}
