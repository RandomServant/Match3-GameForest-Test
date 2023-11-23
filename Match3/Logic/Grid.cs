using Match3.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Match3
{
    public class Grid
    {
        private const int _matchCountForLine = 4;
        private const int _matchCountForBomb = 5;

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

        private bool ExecuteMatch(Vector2 position, ref IElement firstElement, ref List<Bonus> bonuses)
        {
            var matchList = GetMatchList(position, firstElement.Type);

            if (matchList.Count == 0)
                return false;

            if (Game.IsInitialized && !TrySetBonus(matchList, ref firstElement))
            {
                matchList.Add(firstElement);
            }

            foreach (var element in matchList)
            {
                if (element is Bonus)
                    bonuses.Add((Bonus)element);

                element.Destroy(_elements);
            }

            return true;
        }

        private bool TrySetBonus(List<IElement> match, ref IElement elementToBonus)
        {
            bool isEnoughForBomb = match.Count >= _matchCountForBomb - 1;
            bool isEnoughForLine = match.Count == _matchCountForLine - 1;

            if (isEnoughForBomb)
            {
                elementToBonus = new Bomb(elementToBonus.Type, elementToBonus.Position);

                return true;
            }
            if (isEnoughForLine)
            {
                if (match[0].Position.X == elementToBonus.Position.X)
                {
                    elementToBonus = new VerticalLine(elementToBonus.Type, elementToBonus.Position);
                }
                else
                {
                    elementToBonus = new HorizontalLine(elementToBonus.Type, elementToBonus.Position);
                }
                return true;
            }

            return false;
        }

        private List<IElement> GetMatchList(Vector2 position, ElementType type)
        {
            int horizontalCounter = position.X + 1;
            int verticalCounter = position.Y + 1;

            var verticalLine = new List<IElement>();
            var horizontalLine = new List<IElement>();

            while (horizontalCounter < _gridSize)
            {
                if (_elements[horizontalCounter, position.Y].Type != type)
                    break;

                horizontalLine.Add(_elements[horizontalCounter, position.Y]);
                horizontalCounter++;
            }

            while (verticalCounter < _gridSize)
            {
                if (_elements[position.X, verticalCounter].Type != type)
                    break;

                verticalLine.Add(_elements[position.X, verticalCounter]);
                verticalCounter++;
            }

            horizontalCounter = position.X - 1;
            verticalCounter = position.Y - 1;

            while (horizontalCounter >= 0)
            {
                if (_elements[horizontalCounter, position.Y].Type != type)
                    break;

                horizontalLine.Add(_elements[horizontalCounter, position.Y]);
                horizontalCounter--;
            }

            while (verticalCounter >= 0)
            {
                if (_elements[position.X, verticalCounter].Type != type)
                    break;

                verticalLine.Add(_elements[position.X, verticalCounter]);
                verticalCounter--;
            }

            if (verticalLine.Count < 2)
            {
                verticalLine.Clear();
            }
            if (horizontalLine.Count < 2)
            {
                horizontalLine.Clear();
            }

            verticalLine.AddRange(horizontalLine);
            return verticalLine;
        }

        public bool TryMatchAll(out List<Bonus> bonuses)
        {
            bonuses = new List<Bonus>();

            bool isMatched = false;

            for (int i = 0; i < _gridSize; i++)
            {
                for (int j = 0; j < _gridSize; j++)
                {
                    if (ExecuteMatch(new Vector2(i, j), ref _elements[i, j], ref bonuses))
                    {
                        isMatched = true;
                    }
                }
            }
            return isMatched;
        }

        public bool TryMatch(Vector2 firstPosition, Vector2 secondPosition, out List<Bonus> bonuses)
        {
            bonuses = new List<Bonus>();

            var firstTry = ExecuteMatch(secondPosition, ref _elements[secondPosition.X, secondPosition.Y], ref bonuses);
            var secondTry = ExecuteMatch(firstPosition, ref _elements[firstPosition.X, firstPosition.Y], ref bonuses);

            return (firstTry || secondTry);
        }

        public void PushFiguresDown(out List<Vector2> moveFrom, out List<Vector2> moveTo)
        {
            moveFrom = new List<Vector2>();
            moveTo = new List<Vector2>();

            for (int i = 0; i < _gridSize; i++)
            {
                int step = 0;

                for (int j = _gridSize - 1; j >= 0; j--)
                {
                    if (_elements[i, j].IsNull)
                    {
                        step++;
                    }
                    else
                    {
                        SwapElements(new Vector2(i, j + step), new Vector2(i, j));

                        moveFrom.Add(new Vector2(i, j));
                        moveTo.Add(new Vector2(i, j + step));
                    }
                }
            }
        }
    }
}
