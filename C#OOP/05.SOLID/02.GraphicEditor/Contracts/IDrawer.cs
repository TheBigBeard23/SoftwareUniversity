using System;


namespace GraphicEditor.Contracts
{
    interface IDrawer
    {
        void Draw(IShape shape);
        bool IsMatch(IShape shape);
    }
}
