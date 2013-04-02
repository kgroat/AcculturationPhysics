namespace SharpPhysics.Physics.Api
{
    using SharpPhysics.Physics.Api.Impl;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class PhysicsHelper
    {
        public static ILine CreateLine(IVector start, IVector end)
        {
            return new Line((Vector)start, (Vector)end);
        }

        public static ILine CreateLine(float startX, float startY, float endX, float endY)
        {
            return new Line(startX, startY, endX, endY);
        }

        public static ILine CreateBezier3(IVector start, IVector b1, IVector end)
        {
            return new Bezier3((Vector)start, (Vector)b1, (Vector)end);
        }

        public static ILine CreateBezier4(IVector start, IVector b1, IVector b2, IVector end)
        {
            return new Bezier4((Vector)start, (Vector)b1, (Vector)b2, (Vector)end);
        }
    }
}
