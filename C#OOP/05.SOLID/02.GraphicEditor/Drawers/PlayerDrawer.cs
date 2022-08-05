using GraphicEditor.Contracts;
using GraphicEditor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicEditor.Drawers
{
    class PlayerDrawer : IDrawer
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("Drawing Player");
        }

        public bool IsMatch(IShape shape)
        {
            return shape is Player;
        }
    }
}
