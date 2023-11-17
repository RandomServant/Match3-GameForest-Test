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
            return null;
        }
    }
}
