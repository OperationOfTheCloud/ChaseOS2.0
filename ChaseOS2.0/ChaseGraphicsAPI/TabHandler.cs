using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChaseOS2._0.ChaseGraphicsAPI
{
    class TabHandler
{
    private Pen pen;
    public static Int32 rows, columns;
    public TabHandler(Canvas canvas)
    {
        pen = new Pen(Color.White);
        rows = canvas.Mode.Rows;
        columns = canvas.Mode.Columns;
        canvas.DrawRectangle(pen, 0, rows - 100, columns - 2, 99);
        canvas.DrawRectangle(pen, 0, rows - 100, 100, 99);
        canvas.DrawLine(pen, 25, rows - 90, 75, rows - 10);
    }
    public static void ProcessTabBar(Int32 mouseX, Int32 mouseY, Canvas canvas)
    {
        if (new Rectangle(mouseX, mouseY, 1, 1).IntersectsWith(new Rectangle(0, TabHandler.rows - 100, 100, 99)))
        {
            new Window(0, 0, canvas);
        }
    }
}
}
