namespace SharpPhysics.Graphics.Api
{
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

        RectangleF ClipBounds { get; set; }

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


    }
}
