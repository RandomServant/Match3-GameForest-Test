using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Match3
{
    public class BaseElement : IElement
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
            string path;

            switch(Type)
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

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
