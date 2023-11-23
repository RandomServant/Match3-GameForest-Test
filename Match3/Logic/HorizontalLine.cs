using System.Drawing;

namespace Match3.Logic
{
    public class HorizontalLine : Line
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
            return base.GetIconImage();
        }
    }
}
