namespace _02.Graphic_Editor
{
    using System;
    using _02.Graphic_Editor.Interfaces;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}