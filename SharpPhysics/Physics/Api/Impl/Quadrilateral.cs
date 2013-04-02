namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Quadrilateral : IPolygon
    {
        private ObservableCollection<Vector> _Verticies;

        private Vector _Center;

        private float _SignedArea, _Area;

        private List<Line> _Edges;

        private float Radius;

        internal Quadrilateral(Vector point0, Vector point1, Vector point2, Vector point3)
        {
            this._Verticies = new ObservableCollection<Vector>();
            this._Verticies.Add(point0);
            this._Verticies.Add(point1);
            this._Verticies.Add(point2);
            this._Verticies.Add(point3);

            var diag1 = new Line(point0, point2);
            var diag2 = new Line(point1, point3);

            this._Edges = new List<Line>();
            this._Edges.Add(new Line(point0, point1));
            this._Edges.Add(new Line(point1, point2));
            this._Edges.Add(new Line(point2, point3));
            this._Edges.Add(new Line(point3, point0));

            this._Center = null;
            this._Area = -1;
            this.Radius = Edges.Max(e => e.Length);
        }

        internal Vector Center
        {
            get
            {
                if (this._Center == null)
                {
                    this._Center = Polygon.FindCenter(this.Verticies, this.SignedArea);
                }
                return this._Center;
            }
        }

        internal float SignedArea
        {
            get
            {
                if (this._Area < 0)
                {
                    this._SignedArea = Polygon.FindArea(this.Verticies);
                    this._Area = Math.Abs(this._SignedArea);
                }
                return this._SignedArea;
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
                    this._SignedArea = Polygon.FindArea(this.Verticies);
                    this._Area = Math.Abs(this._SignedArea);
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
            if ((Center - point).Length > Radius) return false;
            var lineOfIntersection = new Line((Vector)point, new Vector(Radius, Radius) + point);
            int intersectionCount = Edges.Count(edge => edge.Intersects(lineOfIntersection));
            return (intersectionCount % 2) == 1;
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
