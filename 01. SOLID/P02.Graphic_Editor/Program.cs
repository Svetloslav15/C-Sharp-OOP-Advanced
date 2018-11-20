using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>();
            shapes.Add(new Rectangle());
            shapes.Add(new Circle());
            GraphicEditor graphicEditor = new GraphicEditor();
            foreach (var item in shapes)
            {
                graphicEditor.DrawShape(item);
            }
        }
    }
}
