namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bezier4 : Line
    {
        protected Vector B1, B2;

        public Bezier4(Vector start, Vector b1, Vector b2, Vector end)
            : base(start, end)
        {
            this.B1 = b1;
            this.B2 = b2;
            this._Bounds = new Quadrilateral(start, end, b2, b1);
        }

        public override bool Intersects(Line intersector)
        {
            const float THRESHOLD = 1f / (1024 * 1024);
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
            var t3 = t * t * t;
            var u3 = u * u * u;

            return (u3 * Start) + (3 * u2 * t * B1) + (3 * u * t2 * B2) + (t3 * End);
        }

        public override Tuple<Line, Line> SplitAt(float t)
        {
            var p1 = Start;
            var p2 = B1;
            var p3 = B2;
            var p4 = End;

            var p12 = (p2 - p1) * t + p1;
            var p23 = (p3 - p2) * t + p2;
            var p34 = (p4 - p3) * t + p3;
            var p123 = (p23 - p12) * t + p12;
            var p234 = (p34 - p23) * t + p23;
            var p1234 = (p234 - p123) * t + p123;
            var first = new Bezier4(p1, p12, p123, p1234);

            var p21 = (p1 - p2) * t + p2;
            var p32 = (p2 - p3) * t + p3;
            var p43 = (p3 - p4) * t + p4;
            var p321 = (p32 - p21) * t + p21;
            var p432 = (p43 - p32) * t + p32;
            var p4321 = (p432 - p321) * t + p321;
            var second = new Bezier4(p4, p43, p432, p4321);

            return new Tuple<Line, Line>(first, second);
        }
    }
}
