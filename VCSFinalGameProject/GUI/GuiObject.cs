using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.GUI
{
    abstract class GuiObject
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }

        public GuiObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        abstract public void Render();
    }
}

