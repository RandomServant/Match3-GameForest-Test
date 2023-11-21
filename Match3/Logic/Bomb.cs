using System;
using System.Drawing;
using System.IO;

namespace Match3.Logic
{
    public class Bomb : Bonus
    {
        public Bomb(ElementType type, Vector2 position) : base(type, position) { }

        protected override void ActivateBonus(IElement[,] list)
        {
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
            string path;

            switch (Type)
            {
                case ElementType.Red:
                    path = @"..\..\Visual\Images\RedBomb.png";
                    break;
                case ElementType.Green:
                    path = @"..\..\Visual\Images\GreenBomb.png";
                    break;
                case ElementType.Blue:
                    path = @"..\..\Visual\Images\BlueBomb.png";
                    break;
                case ElementType.Yellow:
                    path = @"..\..\Visual\Images\YellowBomb.png";
                    break;
                default:
                    path = @"..\..\Visual\Images\OrangeBomb.png";
                    break;
            }
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            return Image.FromFile(path);
        }
    }
}
