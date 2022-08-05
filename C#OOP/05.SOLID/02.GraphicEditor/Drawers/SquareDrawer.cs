using GraphicEditor.Contracts;
using GraphicEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.Drawers
{
    class SquareDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing Square");
        }
        public bool IsMatch(IShape shape)
        {
            return shape is Square;
        }
    }
}
