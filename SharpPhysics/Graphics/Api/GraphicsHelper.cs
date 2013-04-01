using SharpPhysics.Graphics.Api.Impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using DrawingGraphics = System.Drawing.Graphics;

namespace SharpPhysics.Graphics.Api
{
    public static class GraphicsHelper
    {
        public static ISharpGraphics CreateGraphicsFromWindow(Window w)
        {
            DrawingGraphics g = DrawingGraphics.FromHwnd(new WindowInteropHelper(w).Handle);
            return new DotNetGraphics(g);
        }

        public static ISharpGraphics CreateGraphicsFromImage(Image i)
        {
            DrawingGraphics g = DrawingGraphics.FromImage(i);
            return new DotNetGraphics(g);
        }
    }
}
