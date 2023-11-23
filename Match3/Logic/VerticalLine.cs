using Match3.Visual;
using System.Drawing;
using System.Threading.Tasks;

namespace Match3.Logic
{
    public class VerticalLine : Line
    {
        public VerticalLine(ElementType type, Vector2 position) : base(type, position) { }

        protected override async void ActivateBonus(IElement[,] elementList)
        {
            await Task.Delay(Animator.LineDestroyDelay);

            for (int i = 0; i < GameWindow.GridSize; i++)
            {
                elementList[Position.X, i].Destroy(elementList);
            }
        }

        public override Image GetIconImage()
        {
            Image image = base.GetIconImage();

            image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            return image;
        }
    }
}
