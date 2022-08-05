using GraphicEditor.Contracts;
using GraphicEditor.Models;
using System;

namespace GraphicEditor.Drawers
{
    class RectangleDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Rectangle;
        }
    }
}
