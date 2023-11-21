using System;
using System.Drawing;
using System.IO;

namespace Match3.Logic
{
    public class HorizontalLine : Bonus
    {

        public HorizontalLine(ElementType type, Vector2 position) : base(type, position) { }

        protected override void ActivateBonus(IElement[,] elementList)
        {
            for (int i = 0; i < GameWindow.GridSize; i++)
            {
                elementList[i, Position.Y].Destroy(elementList);
            }
        }

        public override Image GetIconImage()
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
