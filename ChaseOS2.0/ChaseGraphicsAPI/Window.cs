using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;

namespace ChaseOS2._0.ChaseGraphicsAPI
{
class Window
{
    private List<Tuple<Sys.Graphics.Point, Color>> storePixelsbehindtab;

    public static List<Window> windows = new List<Window>();
    private static Pen outlinePen = new Pen(Color.White);
    internal const Int32 defaultwindowSize = 400, windowTopPartSize = 25, xBtnSize = 25;
    private List<WindowComponent> components;
    public Int32 x
    {
        get;
        private set;
    }
    public Int32 y
    {
        get;
        private set;
    }
    private protected Boolean beingDragged;
    private protected Int32 dragDiffx, dragDiffy;
    public Window(Int32 _x, Int32 _y, Canvas canvas)
    {
        try
        {
            Int32 x = _x, y = _y;
            if (x > (canvas.Mode.Columns - Window.defaultwindowSize) || y > (canvas.Mode.Rows - Window.defaultwindowSize))
            {
                x = canvas.Mode.Columns - (Window.defaultwindowSize + 1);
                y = canvas.Mode.Rows - (Window.defaultwindowSize + 101);
            }
            this.components = new List<WindowComponent>();
            this.beingDragged = false;
            this.x = _x;
            this.y = _y;

            storePixelsbehindtab = new List<Tuple<Sys.Graphics.Point, Color>>();
            Window.windows.Add(this);
            this.draw(canvas);
        }
        catch
        {

        }
    }
    public void draw(Canvas canvas)
    {
        try
        {
                storePixelsbehindTab(canvas);
                canvas.DrawRectangle(Window.outlinePen, x, y, defaultwindowSize, windowTopPartSize);
            canvas.DrawRectangle(Window.outlinePen, x + (defaultwindowSize - xBtnSize), y, xBtnSize, xBtnSize);
            outlinePen.Color = Color.Red;
            canvas.DrawFilledRectangle(Window.outlinePen, x + (Window.defaultwindowSize - Window.xBtnSize - 1), y + 1, xBtnSize, xBtnSize);
            outlinePen.Color = Color.Black;
            canvas.DrawRectangle(Window.outlinePen, x, y + windowTopPartSize, defaultwindowSize, defaultwindowSize - windowTopPartSize);
            foreach (WindowComponent tc in components)
            {
                tc.draw(this);
            }
            
        }
        catch
        {

        }
    }
    public void move(Int32 newX, Int32 newY, Canvas canvas)
    {
        try
        {
            restorePixelsbehindtab(canvas);
            x = newX;
            y = newY;
            this.draw(canvas);
        }
        catch
        {

        }
    }
    public void Close(Canvas canvas)
    {
        try
        {

                restorePixelsbehindtab(canvas);
            Window.windows.Remove(this);

        }
        catch
        {

        }
    }
    public static void tryProcessTabLBDown(Int32 mouseX, Int32 mouseY, Canvas canvas)
    {
        try
        {
            if (Window.windows.Count == 0)
            {
                return;
            }
            foreach (Window window in Window.windows)
            {
                Rectangle mouseLocation = new Rectangle(mouseX, mouseY, 1, 1);
                if (mouseLocation.IntersectsWith(new Rectangle(window.x, window.y, (defaultwindowSize - xBtnSize), windowTopPartSize)))
                {
                    window.dragDiffx = mouseX - window.x;
                    window.dragDiffy = mouseY - window.y;
                    window.beingDragged = true;
                }
                else if (mouseLocation.IntersectsWith(new Rectangle(window.x + (defaultwindowSize - xBtnSize), window.y, xBtnSize, xBtnSize)))
                {
                    window.Close(canvas);
                }
            }
        }
        catch
        {

        }
    }
    public static void tryProcessTabLBUp(Int32 mouseX, Int32 mouseY, Canvas canvas)
    {
        try
        {
            if (Window.windows.Count == 0)
            {
                return;
            }
            foreach (Window window in Window.windows)
            {
                window.beingDragged = false;
                window.move(mouseX - window.dragDiffx, mouseY - window.dragDiffy, canvas);
            }
        }
        catch
        {

        }
    }

    public void storePixelsbehindTab(Canvas canvas)
    {
        try
        {
            storePixelsbehindtab.Clear();
            UInt16 x = 0, y = 0;
            Int32 fixedX, fixedY;

            while (y <= Window.defaultwindowSize)
            {
                x = 0;
                while (x <= Window.defaultwindowSize)
                {
                    fixedX = x;
                    fixedY = y;
                    storePixelsbehindtab.Add(new Tuple<Sys.Graphics.Point, Color>(new Sys.Graphics.Point(fixedX, fixedY), canvas.GetPointColor(fixedX, fixedY)));


                    ++x;
                }
                ++y;
            }

        }
        catch
        {

        }
    }
    public void restorePixelsbehindtab(Canvas canvas)
    {
        try
        {
            canvas.Clear(Color.Gray);
            new TabHandler(canvas);
            foreach (Tuple<Sys.Graphics.Point, Color> pixelData in storePixelsbehindtab)
            {
                canvas.DrawPoint(new Pen(pixelData.Item2), pixelData.Item1);

            }
        }
        catch
        {
                
        }
    }
        public void addComponent(WindowComponent windowComponent, Canvas canvas)
        {
            this.components.Add(windowComponent);
            windowComponent.draw(this);

        }
}
}
