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

        public Game(GameWindow window, int gridSize)
        {
            _window = window;
            _grid = new Grid(gridSize);
        }

        public IElement GetElement(Vector2 position) => _grid.GetElement(position);

        public void SelectElement(Vector2 id)
        {
            
        }
    }
}
