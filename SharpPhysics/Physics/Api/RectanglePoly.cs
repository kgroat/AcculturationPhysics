namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RectanglePoly : Quadrilateral
    {
        public float X { get; internal set; }

        public float Y { get; internal set; }

        public float Width { get; internal set; }

        public float Height { get; internal set; }

        private float Rx, Ry;

        public RectanglePoly(float x, float y, float width, float height) :
            base(new Vector(x, y), new Vector(x, y+height), new Vector(x+width, y+ height), new Vector(x+width, y))
        {
            if (width < 0)
            {
                this.X = x + width;
                this.Width = -width;
            }
            else
            {
                this.X = x;
                this.Width = width;
            }

            if (height < 0)
            {
                this.Y = y + height;
                this.Height = -height;
            }
            else
            {
                this.Y = y;
                this.Height = height;
            }

            this.Rx = this.X + this.Width;
            this.Ry = this.Y + this.Height;
        }

        public override bool IsInside(Vector point)
        {
            return X < point.X && point.X < Rx && Y < point.Y && point.Y < Ry;
        }
    }
}
