using Match3.Logic;
using Match3.Visual;
using System;
using System.Drawing;
using System.IO;

namespace Match3
{
    public class BaseElement : IElement
    {
        public Animator Animator { get; }
        public ElementType Type { get; set; }
        public Vector2 Position { get; set; }

        public bool IsNull { get; protected set; }

        public BaseElement(ElementType type, Vector2 position)
        {
            Type = type;
            Position = position;
            Animator = new Animator();
        }

        public virtual void Destroy(IElement[,] elementList)
        {
            if (IsNull) return;

            ScoreCounter.AddScore();
            IsNull = true;
        }

        public virtual Image GetIconImage()
        {
            Image image;

            switch(Type)
            {
                case ElementType.Red:
                    image = Properties.Resources.Red;
                    break;
                case ElementType.Green:
                    image = Properties.Resources.Green;
                    break;
                case ElementType.Blue:
                    image = Properties.Resources.Blue;
                    break;
                case ElementType.Yellow:
                    image = Properties.Resources.Yellow;
                    break;
                default:
                    image = Properties.Resources.Orange;
                    break;
            }

            return image;
        }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
