using Match3.Logic;
using Match3.Visual;
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
        public static bool IsInitialized { get; private set; } = false;

        private readonly GameWindow _window;
        private readonly Grid _grid;
        private readonly GameTimer _gameTimer;
        private readonly ScoreCounter scoreCounter;

        private GameState _gameState = GameState.BeforeFirstClick;
        private Vector2 _selectedPosition = Vector2.NullVector;

        public Game(GameWindow window, int gridSize)
        {
            _window = window;
            _grid = new Grid(gridSize);
            _gameTimer = new GameTimer(window);
            scoreCounter = new ScoreCounter(window);
        }

        public IElement GetElement(Vector2 position) => _grid.GetElement(position);

        public async void SelectElement(Vector2 id)
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
                    await Task.Delay(Animator.MoveAnimationDelayInMilliseconds);
                    _window.UpdateVisual();
                    await Task.Delay(Animator.VisualUpdateDelayInMilliseconds);
                    if (_grid.TryMatch(_selectedPosition, id))
                    {
                        _window.MarkDeselected(_selectedPosition);
                        _window.DestroyAnimation();
                        await Task.Delay(Animator.DestroyDelayInMilliseconds);
                        _grid.PushFiguresDown(out List<Vector2> moveFrom, out List<Vector2> moveTo);
                        _window.PushDownAnimation(moveFrom, moveTo);
                        await Task.Delay(Animator.PushDownDelayInMilliseconds);
                        _window.UpdateVisual();
                        await Task.Delay(Animator.VisualUpdateDelayInMilliseconds);
                        _grid.RandomFillGrid();
                        _window.UpdateVisual();
                        await Task.Delay(Animator.VisualUpdateDelayInMilliseconds);

                        while (_grid.TryMatchAll())
                        {
                            _window.DestroyAnimation();
                            await Task.Delay(Animator.DestroyDelayInMilliseconds);
                            _grid.PushFiguresDown(out moveFrom, out moveTo);
                            _window.PushDownAnimation(moveFrom, moveTo);
                            await Task.Delay(Animator.PushDownDelayInMilliseconds);
                            _window.UpdateVisual();
                            await Task.Delay(Animator.VisualUpdateDelayInMilliseconds);
                            _grid.RandomFillGrid();
                            _window.UpdateVisual();
                        }
                    }
                    else
                    {
                        _window.MarkDeselected(_selectedPosition);
                        SwapElements(id);
                        _window.UpdateVisual();
                    }
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
            _window.SwapAnimation(GetElement(_selectedPosition), GetElement(position));
        }

        public void Initialize()
        {
            while (_grid.TryMatchAll())
            {
                _grid.RandomFillGrid();
            }
            IsInitialized = true;
        }

        public void InitializeTimer() => _gameTimer.Initialize();
    }
}
