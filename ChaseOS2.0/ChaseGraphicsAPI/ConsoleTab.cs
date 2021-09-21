using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChaseOS2._0.ChaseGraphicsAPI
{
     class ConsoleTab : Window
{
        public Pen cool;
        public ChaseFont font;
        public ConsoleTab(Int32 _x, Int32 _y, Canvas canvas) : base (_x,_y, canvas)
        {
            cool = new Pen(Color.White);
            font = new ChaseFont(Text.defaultFontData);
            this.addComponent(new Text(0, 0, "ChaseOS V34", font, cool));
        }
}
}
