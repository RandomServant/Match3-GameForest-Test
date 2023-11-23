using System.IO;
using System;
using System.Drawing;

namespace Match3.Logic
{
    public class Line : Bonus
    {
        public Line(ElementType type, Vector2 position) : base(type, position) { }

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
