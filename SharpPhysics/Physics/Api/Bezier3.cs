namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bezier3 : Line
    {
        protected Vector B1;

        public Bezier3(Vector start, Vector b1, Vector end)
            : base(start, end)
        {
            this.B1 = b1;
            this._Bounds = new Triangle(start, end, b1);
        }

        public override bool Intersects(Line intersector)
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

            return split1.Item1.Intersects(split2.Item1) || split1.Item1.Intersects(split2.Item2) || split1.Item2.Intersects(split2.Item1) || split1.Item2.Intersects(split2.Item2);
        }

        public override Vector PointOfIntersection(Line intersector)
        {
            throw new NotImplementedException();
        }

        public override Vector PointAtSection(float t)
        {
            var u = 1 - t;
            var t2 = t * t;
            var u2 = u * u;
            return (u2 * Start) + (2 * u * t * B1) + (t2 * End);
        }

        public override Tuple<Line, Line> SplitAt(float t)
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

            return new Tuple<Line, Line>(first, second);
        }
    }
}
