using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.GUI
{
    class MenuLabel : GuiObject
    {
        public bool IsActive { get; private set; } = false;

        public string Label
        {
            get { return _textLine.Label; }
            set { _textLine.Label = value; }
        }

        private string _label = "";

        private Frame _notActiveFrame;
        private Frame _activeFrame;

        private TextLine _textLine;



        public MenuLabel(int x, int y, int width, int height, string buttonText) : base(x, y, width, height)
        {
            _notActiveFrame = new Frame(x, y, width, height, '+');
            _activeFrame = new Frame(x, y, width, height, '#');

            _textLine = new TextLine(x + 1, y + 1 + ((height - 2) / 2), width - 2, buttonText);
        }

        public override void Render()
        {

            _notActiveFrame.Render();
            _textLine.Render();
        }


    }
}
