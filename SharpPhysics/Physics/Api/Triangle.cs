namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Triangle : Polygon
    {
        internal Triangle(Vector point0, Vector point1, Vector point2)
            : base(new ObservableCollection<Vector>() { point0, point1, point2 })
        {
            this._Radius = Edges.Max(e => e.Length);
        }

        public override Vector Center
        {
            get
            {
                if (this._Center == null)
                {
                    this._Center = (this._Verticies[0] + this._Verticies[1] + this._Verticies[2])/3;
                }
                return this._Center;
            }
        }

        public override IList<Vector> Verticies
        {
            get
            {
                return this._Verticies.Select(v => v).ToList();
            }
        }

        public override IList<Line> Edges
        {
            get
            {
                return this._Edges.Select(e => e).ToList();
            }
        }

        public override bool IsInside(Vector point)
        {
            var one = (this._Verticies[1] - this._Verticies[0]).Cross(point);
            var two = (this._Verticies[2] - this._Verticies[0]).Cross(point);
            var three = (this._Verticies[0] - this._Verticies[1]).Cross(point);
            var four = (this._Verticies[2] - this._Verticies[1]).Cross(point);
            return Math.Sign(one) != Math.Sign(two) && Math.Sign(three) != Math.Sign(four);
        }
    }
}
