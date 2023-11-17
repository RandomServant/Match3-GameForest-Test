using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3
{
    public class Grid
    {
        private IElement[,] _elements;
        private int _gridSize;

        private Random _random = new Random();

        public Grid(int gridSize)
        {
            _gridSize = gridSize;
            _elements = new IElement[_gridSize, _gridSize];

            RandomFillGrid();
        }

        public void RandomFillGrid()
        {
            var elementTypes = Enum.GetValues(typeof(ElementType));

            for (int i = 0; i < _gridSize; i++)
            {
                for(int j = 0; j < _gridSize; j++)
                {
                    if (_elements[i, j] == null || _elements[i, j].IsNull)
                    {
                        ElementType randomType = (ElementType)elementTypes.GetValue(_random.Next(elementTypes.Length));

                        _elements[i, j] = new BaseElement(randomType, new Vector2(i, j));
                    }
                }
            }
        }

        public IElement GetElement(Vector2 position) => _elements[position.X, position.Y];

        public void SwapElements(Vector2 firstElementPosition, Vector2 secondElementPosition)
        {
            int x1 = firstElementPosition.X;
            int y1 = firstElementPosition.Y;
            int x2 = secondElementPosition.X;
            int y2 = secondElementPosition.Y;

            (_elements[x1, y1].Position, _elements[x2, y2].Position) = (_elements[x2, y2].Position, _elements[x1, y1].Position);
            (_elements[x1, y1], _elements[x2, y2]) = (_elements[x2, y2], _elements[x1, y1]);
        }
    }
}
