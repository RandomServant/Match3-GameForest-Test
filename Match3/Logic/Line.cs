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
            Image image;

            switch (Type)
            {
                case ElementType.Red:
                    image = Properties.Resources.RedHorizontal;
                    break;
                case ElementType.Green:
                    image = Properties.Resources.GreenHorizontal;
                    break;
                case ElementType.Blue:
                    image = Properties.Resources.BlueHorizontal;
                    break;
                case ElementType.Yellow:
                    image = Properties.Resources.YellowHorizontal;
                    break;
                default:
                    image = Properties.Resources.OrangeHorizontal;
                    break;
            }

            return image;
        }
    }
}
