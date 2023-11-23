using System;
using System.Drawing;
using System.Windows.Forms;

namespace Match3.Visual
{
    public class Animator
    {
        public const int MoveAnimationDelayInMilliseconds = 200;
        public const int PushDownDelayInMilliseconds = 200;
        public const int DestroyDelayInMilliseconds = 280;
        public const int BombBoomDelay = 250;
        public const int LineDestroyDelay = 250;
        public const int VisualUpdateDelayInMilliseconds = 10;

        private const int _timerInterval = 40;
        private int _timeMoveDelay;

        private Timer _timerForMove;
        private Timer _timerForDestroy;

        private Point _currentLocation;
        private Point _targetLocation;
        private Point _moveStep;
        private PictureBox _movableElement;

        private Size _currentSize;
        private Size _targetSize = new Size(0, 0);
        private Size _sizeStep;
        private PictureBox _destuctableElement;

        public Animator()
        {
            _timerForMove = new Timer
            {
                Interval = _timerInterval
            };
            _timerForDestroy = new Timer
            {
                Interval = _timerInterval
            };

            _timerForMove.Tick += MoveTick;
            _timerForDestroy.Tick += DestroyTick;
        }

        private void DestroyTick(object sender, EventArgs e)
        {
            _currentSize = _currentSize - _sizeStep;

            if(_currentSize.Width <= _targetSize.Width)
            {
                _currentSize = _targetSize;
                _timerForDestroy.Stop();
            }
            else
            {
                _destuctableElement.Size = _currentSize;
            }
        }

        public void DestroyAnimation(PictureBox element)
        {
            if (_timerForDestroy.Enabled) return;

            _destuctableElement = element;
            _currentSize = element.Size;

            _sizeStep = new Size(
                (_currentSize.Width - _targetSize.Width) / (DestroyDelayInMilliseconds / _timerInterval),
                (_currentSize.Height - _targetSize.Height) / (DestroyDelayInMilliseconds / _timerInterval));

            _timerForDestroy.Start();
        }

        private void MoveTick(object sender, EventArgs e)
        {
            _currentLocation = new Point(_currentLocation.X + _moveStep.X, _currentLocation.Y + _moveStep.Y);

            _movableElement.Location = _currentLocation;

            if (Math.Abs(_targetLocation.X - _currentLocation.X) < _timeMoveDelay / _timerInterval &&
                Math.Abs(_targetLocation.Y - _currentLocation.Y) < _timeMoveDelay / _timerInterval)
            {
                _timerForMove.Stop();
            }
        }

        public void MoveAnimation(PictureBox element, Point targetPosition, int time)
        {
            if (_timerForMove.Enabled) return;

            _movableElement = element;
            _currentLocation = element.Location;
            _targetLocation = targetPosition;
            _timeMoveDelay = time;

            _moveStep = new Point(
                (_targetLocation.X - _currentLocation.X) / (_timeMoveDelay / _timerInterval),
                (_targetLocation.Y - _currentLocation.Y) / (_timeMoveDelay / _timerInterval));

            _timerForMove.Start();
        }
    }
}
