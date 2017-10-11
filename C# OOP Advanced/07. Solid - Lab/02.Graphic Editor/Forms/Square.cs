namespace _02.Graphic_Editor.Forms
{
    using _02.Graphic_Editor.Interfaces;

    public class Square : IShape
    {
        public string Draw()
        {
            return "I'm Square";
        }
    }
}