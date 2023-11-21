using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Match3.Visual
{
    public class Animator
    {
        public const int MoveAnimationDelayInMilliseconds = 300;
        public const int PushDownDelayInMilliseconds = 500;
        public const int DestroyDelayInMilliseconds = 500;
        public const int VisualUpdateDelayInMilliseconds = 100;

        private const int _timerInterval = 40;

        private Timer _timer;

        private Point _currentLocation;
        private Point _targetLocation;
        private Point _moveStep;
        private PictureBox _movableElement;

        public Animator()
        {
            _timer = new Timer
            {
                Interval = _timerInterval
            };

            _timer.Tick += MoveTick;
        }

        private void MoveTick(object sender, EventArgs e)
        {
            _currentLocation = new Point(_currentLocation.X + _moveStep.X, _currentLocation.Y + _moveStep.Y);

            _movableElement.Location = _currentLocation;

            if (Math.Abs(_targetLocation.X - _currentLocation.X) < MoveAnimationDelayInMilliseconds / _timerInterval &&
                Math.Abs(_targetLocation.Y - _currentLocation.Y) < MoveAnimationDelayInMilliseconds / _timerInterval)
            {
                _timer.Stop();
            }
        }

        public void MoveAnimation(PictureBox element, Point targetPosition)
        {
            _movableElement = element;
            _currentLocation = element.Location;
            _targetLocation = targetPosition;

            _moveStep = new Point(
                (_targetLocation.X - _currentLocation.X) / (MoveAnimationDelayInMilliseconds / _timerInterval),
                (_targetLocation.Y - _currentLocation.Y) / (MoveAnimationDelayInMilliseconds / _timerInterval));

            _timer.Start();
        }
    }
}
