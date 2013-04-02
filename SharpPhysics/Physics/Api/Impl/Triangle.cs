namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Triangle : IPolygon
    {
        private ObservableCollection<Vector> _Verticies;

        private Vector _Center;

        private float _Area;

        private List<Line> _Edges;

        private float Radius;

        internal Triangle(Vector point0, Vector point1, Vector point2)
        {
            this._Verticies = new ObservableCollection<Vector>();
            this._Verticies.Add(point0);
            this._Verticies.Add(point1);
            this._Verticies.Add(point2);

            this._Edges = new List<Line>();
            this._Edges.Add(new Line(point0, point1));
            this._Edges.Add(new Line(point1, point2));
            this._Edges.Add(new Line(point2, point0));
            this.Radius = Edges.Max(e => e.Length);
        }

        internal Vector Center
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

        internal IEnumerable<Vector> Verticies
        {
            get
            {
                return this._Verticies;
            }
        }

        internal IEnumerable<Line> Edges
        {
            get
            {
                return this._Edges;
            }
        }

        IVector IPolygon.Center
        {
            get { return this.Center; }
        }

        public float Area
        {
            get
            {
                if (this._Area < 0)
                {
                    this._Area = this._Edges[0] * this._Edges[1];
                }
                return this._Area;
            }
        }

        IEnumerable<ILine> IPolygon.Edges
        {
            get { return this.Edges.Select(e => e); }
        }

        IEnumerable<IVector> IPolygon.Verticies
        {
            get { return this.Verticies.Select(v => v); }
        }

        public bool IsInside(IVector point)
        {
            var one = (this._Verticies[1] - this._Verticies[0]).Cross(point);
            var two = (this._Verticies[2] - this._Verticies[0]).Cross(point);
            return Math.Sign(one) != Math.Sign(two);
        }

        public bool Intersects(IPolygon polygon)
        {
            if (polygon.Verticies.Any(vertex => this.IsInside(vertex)))
            {
                return true;
            }
            return polygon.Edges.Any(edge => this.Intersects(edge));
        }

        public bool Intersects(ILine line)
        {
            return _Edges.Any(edge => edge.Intersects(line));
        }

        public IPolygon Intersection(IPolygon polygon)
        {
            throw new NotImplementedException();
        }

        public IPolygon Sum(IPolygon polygon)
        {
            throw new NotImplementedException();
        }
    }
}
