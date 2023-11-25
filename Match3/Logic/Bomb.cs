using Match3.Visual;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Match3.Logic
{
    public class Bomb : Bonus
    {
        public Bomb(ElementType type, Vector2 position) : base(type, position) { }

        protected override async void ActivateBonus(IElement[,] list)
        {
            await Task.Delay(Animator.BombBoomDelay);

            for(int i = -1; i <= 1; i++)
            {
                if (Position.X + i < 0 || Position.X + i >= GameWindow.GridSize)
                    continue;

                for (int j = -1; j <= 1; j++) 
                {
                    if (Position.Y + j < 0 || Position.Y + j >= GameWindow.GridSize)
                        continue;

                    list[Position.X + i, Position.Y + j].Destroy(list);
                }
            }
        }

        public override Image GetIconImage()
        {
            Image image;

            switch (Type)
            {
                case ElementType.Red:
                    image = Properties.Resources.RedBomb;
                    break;
                case ElementType.Green:
                    image = Properties.Resources.GreenBomb;
                    break;
                case ElementType.Blue:
                    image = Properties.Resources.BlueBomb;
                    break;
                case ElementType.Yellow:
                    image = Properties.Resources.YellowBomb;
                    break;
                default:
                    image = Properties.Resources.OrangeBomb;
                    break;
            }

            return image;
        }
    }
}
