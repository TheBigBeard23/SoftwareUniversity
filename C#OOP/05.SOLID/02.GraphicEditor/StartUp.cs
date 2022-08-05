
using GraphicEditor.Contracts;
using GraphicEditor.Models;
using System;

namespace GraphicEditor
{
    public class StartUp
    {
        static void Main()
        {
            DrawingManager drawer = new DrawingManager();
            Circle circle = new Circle();
            Square square = new Square();
            Rectangle rectangle = new Rectangle();
            Player player = new Player();

            drawer.Draw(circle);
            drawer.Draw(square);
            drawer.Draw(rectangle);
            drawer.Draw(player);
        }
    }
}
