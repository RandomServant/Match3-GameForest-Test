using Match3.Visual;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Match3
{
    public interface IElement
    {
        Animator Animator { get; set; }
        ElementType Type { get; set; }
        Vector2 Position { get; set; }
        bool IsNull { get; }
        void Destroy(IElement[,] elementList);
        Image GetIconImage();
    }
}
