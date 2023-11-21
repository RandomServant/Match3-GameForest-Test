using System;
using System.Drawing;
using System.IO;

namespace Match3.Logic
{
    public class VerticalLine : Bonus
    {
        public VerticalLine(ElementType type, Vector2 position) : base(type, position) { }

        protected override void ActivateBonus(IElement[,] elementList)
        {
            for (int i = 0; i < GameWindow.GridSize; i++)
            {
                elementList[Position.X, i].Destroy(elementList);
            }
        }

        public override Image GetIconImage()
        {
            string path;

            switch (Type)
            {
                case ElementType.Red:
                    path = @"..\..\Visual\Images\RedVertical.png";
                    break;
                case ElementType.Green:
                    path = @"..\..\Visual\Images\GreenVertical.png";
                    break;
                case ElementType.Blue:
                    path = @"..\..\Visual\Images\BlueVertical.png";
                    break;
                case ElementType.Yellow:
                    path = @"..\..\Visual\Images\YellowVertical.png";
                    break;
                default:
                    path = @"..\..\Visual\Images\OrangeVertical.png";
                    break;
            }
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            return Image.FromFile(path);
        }
    }
}
