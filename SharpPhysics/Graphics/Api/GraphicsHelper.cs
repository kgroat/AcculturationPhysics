using SharpPhysics.Graphics.Api.Impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace SharpPhysics.Graphics.Api
{
    public static class GraphicsHelper
    {
        public static ISharpGraphics CreateGraphicsFromWindow(Window w)
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(new WindowInteropHelper(w).Handle);
            return new DotNetGraphics(g);
        }

        public static ISharpGraphics CreateGraphicsFromImage(Image i)
        {
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(i);
            return new DotNetGraphics(g);
        }

        public static ISharpGraphics CreateGraphicsFromGraphics(System.Drawing.Graphics g)
        {
            return new DotNetGraphics(g);
        }

        public static IRenderContext CreateRenderContext(int width, int height, float scale)
        {
            return null;
        }

        public static void BindRenderContext()
        {

        }
    }
}
