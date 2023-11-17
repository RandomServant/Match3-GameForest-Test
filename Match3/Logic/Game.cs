using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Match3
{
    internal class Game
    {
        private readonly GameWindow _window;
        private readonly Grid _grid;

        public Game(GameWindow window, int gridSize)
        {
            _window = window;
            _grid = new Grid(gridSize);
        }
    }
}
