namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Bezier3 : Line
    {
        private Vector B1;

        public Bezier3(Vector start, Vector b1, Vector end)
            : base(start, end)
        {
            this.B1 = b1;
            this._Bounds = new Triangle(start, end, b1);
        }

        public virtual bool Intersects(ILine intersector)
        {
            const float THRESHOLD = 1f/(1024*1024);
            var other = (Line)intersector;

            if (!this.Bounds.Intersects(other.Bounds))
            {
                return false;
            }

            if (this.Bounds.Area + other.Bounds.Area < THRESHOLD)
            {
                return true;
            }

            var split1 = this.SplitAt(.5f);
            var split2 = other.SplitAt(.5f);

            return split1[0].Intersects(split2[0]) || split1[0].Intersects(split2[1]) || split1[1].Intersects(split2[0]) || split1[1].Intersects(split2[1]);
        }

        public virtual Vector PointOfIntersection(ILine intersector)
        {
            throw new NotImplementedException();
        }

        public virtual IVector PointAtSection(float t)
        {
            var u = 1 - t;
            var t2 = t * t;
            var u2 = u * u;
            return (u2 * Start) + (2 * u * t * B1) + (t2 * End);
        }

        internal virtual Line[] SplitAt(float t)
        {
            var p1 = Start;
            var p2 = B1;
            var p3 = End;

            var p12 = (p2 - p1) * t + p1;
            var p23 = (p3 - p2) * t + p2;
            var p123 = (p23 - p12) * t + p12;
            var first = new Bezier3(p1, p12, p123);

            var p21 = (p1 - p2) * t + p2;
            var p32 = (p2 - p3) * t + p3;
            var p321 = (p32 - p21) * t + p21;
            var second = new Bezier3(p3, p32, p321);

            return new Line[] { first, second };
        }
    }
}
