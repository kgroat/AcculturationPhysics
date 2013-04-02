namespace SharpPhysics.Graphics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DotNetGraphics : ISharpGraphics
    {
        private Graphics g;

        internal DotNetGraphics(Graphics g)
        {
            this.g = g;
        }

        public Region Clip
        {
            get
            {
                return g.Clip;
            }
            set
            {
                g.Clip = value;
            }
        }

        public RectangleF ClipBounds
        {
            get
            {
                return g.ClipBounds;
            }
        }

        public System.Drawing.Drawing2D.CompositingMode CompositingMode
        {
            get
            {
                return g.CompositingMode;
            }
        }

        public System.Drawing.Drawing2D.CompositingQuality CompositingQuality
        {
            get
            {
                return g.CompositingQuality;
            }
            set
            {
                g.CompositingQuality = value;
            }
        }

        public float DpiX
        {
            get
            {
                return g.DpiX;
            }
        }

        public float DpiY
        {
            get
            {
                return g.DpiY;
            }
        }

        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode
        {
            get
            {
                return g.InterpolationMode;
            }
            set
            {
                g.InterpolationMode = value;
            }
        }

        public bool IsClipEmpty
        {
            get
            {
                return g.IsClipEmpty;
            }
        }

        public bool IsVisibleClipEmpty
        {
            get
            {
                return g.IsVisibleClipEmpty;
            }
        }

        public float PageScale
        {
            get
            {
                return g.PageScale;
            }
            set
            {
                g.PageScale = value;
            }
        }

        public GraphicsUnit PageUnit
        {
            get
            {
                return g.PageUnit;
            }
            set
            {
                g.PageUnit = value;
            }
        }

        public System.Drawing.Drawing2D.PixelOffsetMode PixelOffsetMode
        {
            get
            {
                return g.PixelOffsetMode;
            }
            set
            {
                g.PixelOffsetMode = value;
            }
        }

        public Point RenderingOrigin
        {
            get
            {
                return g.RenderingOrigin;
            }
            set
            {
                g.RenderingOrigin = value;
            }
        }

        public System.Drawing.Drawing2D.SmoothingMode SmoothingMode
        {
            get
            {
                return g.SmoothingMode;
            }
            set
            {
                g.SmoothingMode = value;
            }
        }

        public int TextContrast
        {
            get
            {
                return g.TextContrast;
            }
            set
            {
                g.TextContrast = value;
            }
        }

        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return g.TextRenderingHint;
            }
            set
            {
                g.TextRenderingHint = value;
            }
        }

        public System.Drawing.Drawing2D.Matrix Transform
        {
            get
            {
                return g.Transform;
            }
            set
            {
                g.Transform = value;
            }
        }

        public RectangleF VisibleClipBounds
        {
            get
            {
                return g.VisibleClipBounds;
            }
        }

        public void DrawLine(Pen p, Point start, Point end)
        {
            g.DrawLine(p, start, end);
        }

        public void DrawLine(Pen p, PointF start, PointF end)
        {
            g.DrawLine(p, start, end);
        }

        public void DrawLine(Pen p, int startX, int startY, int endX, int endY)
        {
            g.DrawLine(p, startX, startY, endX, endY);
        }

        public void DrawLine(Pen p, float startX, float startY, float endX, float endY)
        {
            g.DrawLine(p, startX, startY, endX, endY);
        }

        public void DrawLine(Pen p, Physics.Api.IVector start, Physics.Api.IVector end)
        {
            g.DrawLine(p, start.ToPoint(), end.ToPoint());
        }

        public void DrawLine(Pen p, Physics.Api.ILine line)
        {
            g.DrawLine(p, line.Start.ToPoint(), line.End.ToPoint());
        }

        public void DrawLines(Pen p, IEnumerable<Point> points)
        {
            g.DrawLines(p, points.ToArray());
        }

        public void DrawLines(Pen p, IEnumerable<PointF> points)
        {
            g.DrawLines(p, points.ToArray());
        }

        public void DrawLines(Pen p, IEnumerable<Physics.Api.IVector> points)
        {
            g.DrawLines(p, points.Select(v => v.ToPoint()).ToArray());
        }

        public void DrawLines(Pen p, IEnumerable<Physics.Api.ILine> lines)
        {
            lines.Each(line => this.DrawLine(p, line));
        }

        public void DrawImage(Image i, Point location)
        {
            this.g.DrawImage(i, location);
        }

        public void DrawImage(Image i, PointF location)
        {
            this.g.DrawImage(i, location);
        }

        public void DrawImage(Image i, int x, int y)
        {
            this.g.DrawImage(i, x, y);
        }

        public void DrawImage(Image i, float x, float y)
        {
            this.g.DrawImage(i, x, y);
        }

        public void DrawImage(Image i, Point location, Size size)
        {
            this.g.DrawImage(i, new RectangleF(location, size));
        }

        public void DrawImage(Image i, PointF location, SizeF size)
        {
            this.g.DrawImage(i, new RectangleF(location, size));
        }

        public void DrawImage(Image i, int x, int y, int width, int height)
        {
            this.g.DrawImage(i, x, y, width, height);
        }

        public void DrawImage(Image i, float x, float y, float width, float height)
        {
            this.g.DrawImage(i, x, y, width, height);
        }

        public void DrawImage(Image i, Physics.Api.IVector location)
        {
            this.g.DrawImage(i, location.ToPoint());
        }

        public void DrawImage(Image i, Physics.Api.IVector location, Physics.Api.IVector size)
        {
            this.g.DrawImage(i, new RectangleF(location.X, location.Y, size.X, size.Y));
        }

        public void DrawPolygon(Pen p, IEnumerable<Point> points)
        {
            g.DrawPolygon(p, points.ToArray());
        }

        public void DrawPolygon(Pen p, IEnumerable<PointF> points)
        {
            g.DrawPolygon(p, points.ToArray());
        }

        public void DrawPolygon(Pen p, Physics.Api.IPolygon polygon)
        {
            this.DrawPolygon(p, polygon.Verticies.Select(v => v.ToPoint()));
        }

        public void DrawRectangle(Pen p, Rectangle rectangle)
        {
            g.DrawRectangle(p, rectangle);
        }

        public void DrawRectangle(Pen p, RectangleF rectangle)
        {
            g.DrawRectangle(p, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public void DrawRectangle(Pen p, Point location, Size size)
        {
            g.DrawRectangle(p, location.X, location.Y, size.Width, size.Height);
        }

        public void DrawRectangle(Pen p, PointF location, SizeF size)
        {
            g.DrawRectangle(p, location.X, location.Y, size.Width, size.Height);
        }

        public void DrawRectangle(Pen p, int x, int y, int width, int height)
        {
            g.DrawRectangle(p, x, y, width, height);
        }

        public void DrawRectangle(Pen p, float x, float y, float width, float height)
        {
            g.DrawRectangle(p, x, y, width, height);
        }

        public void DrawRectangle(Pen p, Physics.Api.IVector location, Physics.Api.IVector size)
        {
            g.DrawRectangle(p, location.X, location.Y, size.X, size.Y);
        }

        public void DrawString(string s, Font font, Brush brush, Point location)
        {
            g.DrawString(s, font, brush, location);
        }

        public void DrawString(string s, Font font, Brush brush, PointF location)
        {
            g.DrawString(s, font, brush, location);
        }

        public void DrawString(string s, Font font, Brush brush, Rectangle layout)
        {
            g.DrawString(s, font, brush, layout);
        }

        public void DrawString(string s, Font font, Brush brush, RectangleF layout)
        {
            g.DrawString(s, font, brush, layout);
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y)
        {
            g.DrawString(s, font, brush, x, y);
        }

        public void DrawString(string s, Font font, Brush brush, float x, float y, float width, float height)
        {
            g.DrawString(s, font, brush, new RectangleF(x, y, width, height));
        }

        public void DrawString(string s, Font font, Brush brush, int x, int y)
        {
            g.DrawString(s, font, brush, x, y);
        }

        public void DrawString(string s, Font font, Brush brush, int x, int y, int width, int height)
        {
            g.DrawString(s, font, brush, new Rectangle(x, y, width, height));
        }

        public void DrawString(string s, Font font, Brush brush, Physics.Api.IVector location)
        {
            g.DrawString(s, font, brush, location.ToPoint());
        }

        public void DrawString(string s, Font font, Brush brush, Physics.Api.IVector location, Physics.Api.IVector size)
        {
            g.DrawString(s, font, brush, new RectangleF(location.ToPoint(), size.ToSize()));
        }

        public void FillPolygon(Brush b, IEnumerable<Point> points)
        {
            g.FillPolygon(b, points.ToArray());
        }

        public void FillPolygon(Brush b, IEnumerable<PointF> points)
        {
            g.FillPolygon(b, points.ToArray());
        }

        public void FillPolygon(Brush b, Physics.Api.IPolygon polygon)
        {
            this.FillPolygon(b, polygon.Verticies.Select(v => v.ToPoint()));
        }

        public void FillRectangle(Brush b, Rectangle rectangle)
        {
            g.FillRectangle(b, rectangle);
        }

        public void FillRectangle(Brush b, RectangleF rectangle)
        {
            g.FillRectangle(b, rectangle);
        }

        public void FillRectangle(Brush b, Point location, Size size)
        {
            g.FillRectangle(b, location.X, location.Y, size.Width, size.Height);
        }

        public void FillRectangle(Brush b, PointF location, SizeF size)
        {
            g.FillRectangle(b, location.X, location.Y, size.Width, size.Height);
        }

        public void FillRectangle(Brush b, int x, int y, int width, int height)
        {
            g.FillRectangle(b, x, y, width, height);
        }

        public void FillRectangle(Brush b, float x, float y, float width, float height)
        {
            g.FillRectangle(b, x, y, width, height);
        }

        public void FillRectangle(Brush b, Physics.Api.IVector location, Physics.Api.IVector size)
        {
            g.FillRectangle(b, location.X, location.Y, size.X, size.Y);
        }

        public SizeF MeasureString(string text, Font font)
        {
            return g.MeasureString(text, font);
        }

        public SizeF MeasureString(string text, Font font, int width)
        {
            return g.MeasureString(text, font, width);
        }

        public SizeF MeasureString(string text, Font font, SizeF layoutArea)
        {
            return g.MeasureString(text, font, layoutArea);
        }
    }
}
