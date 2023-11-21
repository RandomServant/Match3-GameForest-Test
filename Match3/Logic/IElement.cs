using Match3.Visual;
using System.Drawing;

namespace Match3
{
    public interface IElement
    {
        Animator Animator { get; }
        ElementType Type { get; set; }
        Vector2 Position { get; set; }
        bool IsNull { get; }
        void Destroy(IElement[,] elementList);
        Image GetIconImage();
    }
}
