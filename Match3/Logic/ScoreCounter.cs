namespace Match3.Logic
{
    public class ScoreCounter
    {
        private const int _scoreForElement = 100;

        private static int _currentScore = 0;
        private static GameWindow _window;

        public ScoreCounter(GameWindow window)
        {
            _window = window;
        }

        public static void AddScore()
        {
            if (!_window.IsWindowInitialized)
                return;
                
            _currentScore += _scoreForElement;

            _window.UpdateScoreText(_currentScore.ToString());
        }
    }
}
