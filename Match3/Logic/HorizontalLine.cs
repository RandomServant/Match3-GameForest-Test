using Match3.Visual;
using System.Drawing;
using System.Threading.Tasks;

namespace Match3.Logic
{
    public class HorizontalLine : Line
    {

        public HorizontalLine(ElementType type, Vector2 position) : base(type, position) { }

        protected override async void ActivateBonus(IElement[,] elementList)
        {
            await Task.Delay(Animator.LineDestroyDelay);

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
