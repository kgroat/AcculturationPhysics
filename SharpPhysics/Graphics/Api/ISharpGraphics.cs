namespace SharpPhysics.Graphics.Api
{
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISharpGraphics
    {
        Region Clip { get; set; }

        RectangleF ClipBounds { get; }

        CompositingMode CompositingMode { get; }

        CompositingQuality CompositingQuality { get; set; }

        float DpiX { get; }

        float DpiY { get; }

        InterpolationMode InterpolationMode { get; set; }

        bool IsClipEmpty { get; }

        bool IsVisibleClipEmpty { get; }

        float PageScale { get; set; }

        GraphicsUnit PageUnit { get; set; }

        PixelOffsetMode PixelOffsetMode { get; set; }

        Point RenderingOrigin { get; set; }

        SmoothingMode SmoothingMode { get; set; }

        int TextContrast { get; set; }

        TextRenderingHint TextRenderingHint { get; set; }

        Matrix Transform { get; set; }

        RectangleF VisibleClipBounds { get; }

        void DrawLine(Pen p, Point start, Point end);

        void DrawLine(Pen p, PointF start, PointF end);

        void DrawLine(Pen p, int startX, int startY, int endX, int endY);

        void DrawLine(Pen p, float startX, float startY, float endX, float endY);

        void DrawLine(Pen p, Vector start, Vector end);

        void DrawLine(Pen p, Line line);

        void DrawLines(Pen p, IEnumerable<Point> points);

        void DrawLines(Pen p, IEnumerable<PointF> points);

        void DrawLines(Pen p, IEnumerable<Vector> points);

        void DrawLines(Pen p, IEnumerable<Line> points);

        void DrawImage(Image i, Point location);

        void DrawImage(Image i, PointF location);

        void DrawImage(Image i, int x, int y);

        void DrawImage(Image i, float x, float y);

        void DrawImage(Image i, Point location, Size size);

        void DrawImage(Image i, PointF location, SizeF size);

        void DrawImage(Image i, int x, int y, int width, int height);

        void DrawImage(Image i, float x, float y, float width, float height);

        void DrawImage(Image i, Vector location);

        void DrawImage(Image i, Vector location, Vector size);

        void DrawPolygon(Pen p, IEnumerable<Point> points);

        void DrawPolygon(Pen p, IEnumerable<PointF> points);

        void DrawPolygon(Pen p, Polygon polygon);

        void DrawRectangle(Pen p, Rectangle rectangle);

        void DrawRectangle(Pen p, RectangleF rectangle);

        void DrawRectangle(Pen p, Point location, Size size);

        void DrawRectangle(Pen p, PointF location, SizeF size);

        void DrawRectangle(Pen p, int x, int y, int width, int height);

        void DrawRectangle(Pen p, float x, float y, float width, float height);

        void DrawRectangle(Pen p, Vector location, Vector size);

        void DrawString(string s, Font font, Brush brush, Point location);

        void DrawString(string s, Font font, Brush brush, PointF location);

        void DrawString(string s, Font font, Brush brush, Rectangle layout);

        void DrawString(string s, Font font, Brush brush, RectangleF layout);

        void DrawString(string s, Font font, Brush brush, float x, float y);

        void DrawString(string s, Font font, Brush brush, float x, float y, float width, float height);

        void DrawString(string s, Font font, Brush brush, int x, int y);

        void DrawString(string s, Font font, Brush brush, int x, int y, int width, int height);

        void DrawString(string s, Font font, Brush brush, Vector location);

        void DrawString(string s, Font font, Brush brush, Vector location, Vector size);

        void FillPolygon(Brush b, IEnumerable<Point> points);

        void FillPolygon(Brush b, IEnumerable<PointF> points);

        void FillPolygon(Brush b, Polygon polygon);

        void FillRectangle(Brush b, Rectangle rectangle);

        void FillRectangle(Brush b, RectangleF rectangle);

        void FillRectangle(Brush b, Point location, Size size);

        void FillRectangle(Brush b, PointF location, SizeF size);

        void FillRectangle(Brush b, int x, int y, int width, int height);

        void FillRectangle(Brush b, float x, float y, float width, float height);

        void FillRectangle(Brush b, Vector location, Vector size);

        SizeF MeasureString(string text, Font font);

        SizeF MeasureString(string text, Font font, int width);

        SizeF MeasureString(string text, Font font, SizeF layoutArea);
    }
}
