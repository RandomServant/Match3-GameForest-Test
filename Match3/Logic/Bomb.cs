using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3.Logic
{
    public class Bomb : IElement
    {
        public ElementType Type { get; set; }
        public Vector2 Position { get; set; }

        public bool IsNull { get; private set; }

        public Bomb(IElement element)
        {
            Position = element.Position;
            Type = ElementType.Bomb;
        }

        public void Destroy(IElement[,] elementList)
        {
            if (IsNull)
                return;

            ScoreCounter.AddScore();
            IsNull = true;
            ActivateBonus(elementList);
        }

        private void ActivateBonus(IElement[,] list)
        {
            for(int i = -1; i <= 1; i++)
            {
                if (Position.Y + i < 0 || Position.Y + i >= GameWindow.GridSize)
                    continue;

                for (int j = -1; j <= 1; j++) 
                {
                    if (Position.X + j < 0 || Position.X + j >= GameWindow.GridSize)
                        continue;

                    list[i, j].Destroy(list);
                }
            }
        }

        public Image GetIconImage()
        {
            string path = @"..\..\Visual\Images\Bomb.png";

            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            return Image.FromFile(path);
        }
    }
}
