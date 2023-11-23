using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3.Visual
{
    public class Destroyer : PictureBox
    {
        public Animator Animator = new Animator();

        public Destroyer(Point location)
        {
            Image = Properties.Resources.Destroyer;
            Size = new Size(GameWindow.CellGridSize, GameWindow.CellGridSize);
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = location;
            Enabled = false;
        }
    }
}
