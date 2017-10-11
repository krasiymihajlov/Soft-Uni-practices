namespace _02.Graphic_Editor.Forms
{
    using System;
    using _02.Graphic_Editor.Interfaces;

    public class Circle : IShape
    {
        public string Draw()
        {
            return "I'm Circle";
        }
    }
}