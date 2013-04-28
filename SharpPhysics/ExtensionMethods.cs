namespace SharpPhysics
{
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ExtensionMethods
    {
        public static void DrawPolygon(this System.Drawing.Graphics g, Pen pen, Polygon polygon)
        {
            var rect = polygon as RectanglePoly;
            if (rect != null)
            {
                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                g.DrawPolygon(pen, polygon.Verticies.Select(v => v.ToPoint()).ToArray());
            }
        }

        public static void FillPolygon(this System.Drawing.Graphics g, Brush brush, Polygon polygon)
        {
            var rect = polygon as RectanglePoly;
            if (rect != null)
            {
                g.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                var tmp = polygon.Verticies.Select(v => v.ToPoint()).ToArray();
                g.FillPolygon(brush, tmp);
            }
        }



        public static void AddPolygon(this GraphicsPath self, Polygon polygon)
        {
            self.StartFigure();
            polygon.Edges.Each(edge => self.AddLine(edge));
            self.CloseFigure();
        }

        public static void AddLine(this GraphicsPath self, Line line)
        {
            var bz4 = line as Bezier4;
            if (bz4 != null)
            {
                self.AddBezier(bz4.Start.ToPoint(), bz4.B1.ToPoint(), bz4.B2.ToPoint(), bz4.End.ToPoint());
            }
            else
            {
                self.AddLine(line.Start.ToPoint(), line.End.ToPoint());
            }

        }



        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var each in self)
            {
                action(each);
            }
        }
    }
}
