using Sys = Cosmos.System;
using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChaseOS2._0.ChaseGraphicsAPI
{
    class Graphics
    {
        public static bool THE;
        private Canvas canvas;
        private Pen pen;
        private int Cache;
        private TabHandler tabHandler;
        private WindowComponent window;
        private MouseState mouseState;
        public static MouseState prevmouseState;
        private UInt32 px, py;
        private List<Tuple<Sys.Graphics.Point, Color>> savedPixels;
        public static bool ART;
        public Graphics()
        {

            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.Gray);
            pen = new Pen(Color.White);
            mouseState = MouseState.None;
            px = 3;
            py = 3;
            savedPixels = new List<Tuple<Sys.Graphics.Point, Color>>();
            tabHandler = new TabHandler(canvas);
            MouseManager.ScreenHeight = (UInt32)canvas.Mode.Rows;
            MouseManager.ScreenWidth = (UInt32)canvas.Mode.Columns;

            if (THE == true)
            {
                for (int i = 0; i <= 350; i++)
                {
                    canvas.DrawRectangle(pen, i, i, i, i);
                    pen.Color = Color.Blue;
                }
            }
            pen.Color = Color.White;
        }
        public void Button(int size, int x, int y, Pen draw)
        {
            for (int i = 0; i <= size; i++)
            {
                canvas.DrawRectangle(draw, x, y, i, i);
            }
        }

        public void MouseHandler()
        {

            px = MouseManager.X;
            py = MouseManager.Y;
            mouseState = MouseManager.MouseState;
            Sys.Graphics.Point[] points = new Sys.Graphics.Point[]
            {
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+2),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+2),
            };
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in savedPixels)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);
            }
            foreach (Sys.Graphics.Point p in points)
            {
                savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, canvas.GetPointColor(p.X, p.Y)));
                canvas.DrawPoint(pen, p);
            }
            if (mouseState == MouseState.Left && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBDown((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
                TabHandler.ProcessTabBar((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }
            else if (mouseState == MouseState.None && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBUp((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }

            pen.Color = Color.White;
            prevmouseState = mouseState;
        }
        public void ArtHandler()
        {
            px = MouseManager.X;
            py = MouseManager.Y;
            mouseState = MouseManager.MouseState;
            Sys.Graphics.Point[] points = new Sys.Graphics.Point[]
            {
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+1, (int)MouseManager.Y+2),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+1),
                    new Sys.Graphics.Point((int)MouseManager.X+2, (int)MouseManager.Y+2),
            };
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in savedPixels)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);
            }
            foreach (Sys.Graphics.Point p in points)
            {
                savedPixels.Add(new Tuple<Sys.Graphics.Point, Color>(p, canvas.GetPointColor(p.X, p.Y)));
                canvas.DrawPoint(pen, p);
            }
            if (mouseState == MouseState.Left && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBDown((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
                TabHandler.ProcessTabBar((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }
            else if (mouseState == MouseState.None && prevmouseState == MouseState.Left)
            {
                Window.tryProcessTabLBUp((Int32)MouseManager.X, (Int32)MouseManager.Y, canvas);
            }
            savedPixels.Clear();
            pen.Color = Color.White;
            prevmouseState = mouseState;
        }
    }
}
