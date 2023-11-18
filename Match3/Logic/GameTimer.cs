using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3.Logic
{
    public class GameTimer
    {
        private readonly GameWindow _window;

        private int _durrationOfGameInSeconds = 60;

        private Timer _timer;

        public GameTimer(GameWindow window)
        {
            _window = window;

            _timer = new Timer
            {
                Interval = 1000
            };

            _timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _durrationOfGameInSeconds--;

            if(_durrationOfGameInSeconds < 0)
            {
                _timer.Stop();
                _window.GameOver();
            }
            else
            {
                _window.UpdateTimerText(_durrationOfGameInSeconds.ToString());
            }
        }

        public void Initialize()
        {
            _timer.Start();
        }
    }
}
