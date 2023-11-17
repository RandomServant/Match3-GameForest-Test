using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3
{
    internal class BaseElement : IElement
    {
        public ElementType Type { get; set; }
        public Vector2 Position { get; set; }

        public bool IsNull { get; private set; }

        public BaseElement(ElementType type, Vector2 position)
        {
            Type = type;
            Position = position;
        }

        public void Destroy(IElement[,] elementList)
        {
            if (IsNull) return;

            IsNull = true;
        }

        public Image GetIconImage()
        {
            Image icon;

            switch(Type)
            {
                case ElementType.Red:
                    icon = Image.FromFile("../Visual/Images/Red.png");
                    break;
                case ElementType.Green:
                    icon = Image.FromFile("../Visual/Images/Green.png");
                    break;
                case ElementType.Blue:
                    icon = Image.FromFile("../Visual/Images/Blue.png");
                    break;
                case ElementType.Yellow:
                    icon = Image.FromFile("../Visual/Images/Yellow.png");
                    break;
                default:
                    icon = Image.FromFile("../Visual/Images/Orange.png");
                    break;
            }

            return icon;
        }
    }
}
