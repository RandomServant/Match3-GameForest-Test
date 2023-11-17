using Match3.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Match3
{
    public class Game
    {
        private readonly GameWindow _window;
        private readonly Grid _grid;

        private GameState _gameState = GameState.BeforeFirstClick;
        private Vector2 _selectedPosition = Vector2.NullVector;

        public Game(GameWindow window, int gridSize)
        {
            _window = window;
            _grid = new Grid(gridSize);
        }

        public IElement GetElement(Vector2 position) => _grid.GetElement(position);

        public void SelectElement(Vector2 id)
        {
            if(_gameState == GameState.BeforeFirstClick)
            {
                _selectedPosition = id;
                _window.MarkSelected(id);
                _gameState = GameState.AfterFirstClick;
            }
            else if(_gameState == GameState.AfterFirstClick)
            {
                if(_selectedPosition.IsNearby(id))
                {
                    _gameState = GameState.Animation;
                    SwapElements(id);
                }
                else
                {
                    _window.MarkDeselected(_selectedPosition);
                }
                _gameState = GameState.BeforeFirstClick;
                _selectedPosition = Vector2.NullVector;
            }
        }

        private void SwapElements(Vector2 position)
        {
            _grid.SwapElements(_selectedPosition, position);
        }
    }
}
