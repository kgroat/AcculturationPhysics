namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Polygon : IPolygon
    {
        private Vector _Center;

        private float _SignedArea;

        private float _Area;

        private ObservableCollection<Line> _Edges;

        private bool EdgesSorted, VerticesFound;

        private float _Radius;

        private IEnumerable<Vector> _Vertices;

        internal Polygon(IEnumerable<Line> Edges)
        {
            this._Edges = new ObservableCollection<Line>(Edges);
            this._Edges.CollectionChanged += _Edges_CollectionChanged;
            this.InitializeValues();
            this.SortEdges();
        }

        internal float Radius
        {
            get
            {
                if (this._Radius <= 0)
                {
                    this._Radius = _Edges.Max(edge => (this._Center - edge.End).Length);
                }
                return _Radius;
            }
        }

        internal Vector Center
        {
            get
            {
                if (this._Center == null)
                {
                    this._Center = FindCenter(this.Verticies, this.Area);
                }
                return this._Center;
            }
            set
            {
                if (this._Center == null)
                {
                    this._Center = FindCenter(this.Verticies, this.Area);
                }

                if (this._Center != value)
                {
                    SortEdges();
                    var change = value - _Center;
                    this._Center = value;
                    int j = _Edges.Count() - 1;
                    for (int i = 0; i < _Edges.Count(); i++)
                    {
                        _Edges[i].End = change + _Edges[i].End;
                        _Edges[j].Start = _Edges[i].End;
                        j = i;
                    }
                }
            }
        }

        internal float Area
        {
            get
            {
                if (this._Area <= 0)
                {
                    this._SignedArea = FindArea(this.Verticies);
                    this._Area = Math.Abs(this._SignedArea);
                }
                return _Area;
            }
        }

        internal float SignedArea
        {
            get
            {
                if (this._Area <= 0)
                {
                    this._SignedArea = this.CalculateArea();
                    this._Area = Math.Abs(this._SignedArea);
                }
                return _SignedArea;
            }
        }

        internal Collection<Line> Edges
        {
            get
            {
                if (!this.EdgesSorted)
                {
                    this.SortEdges();
                }
                return _Edges;
            }
        }

        internal IEnumerable<Vector> Verticies
        {
            get
            {
                if (!this.VerticesFound)
                {
                    this._Vertices = this.Edges.Select(edge => edge.End);
                    this.VerticesFound = true;
                }
                return this._Vertices;
            }
        }

        IVector IPolygon.Center
        {
            get { return this._Center; }
        }

        float IPolygon.Area
        {
            get { return this.Area; }
        }

        IEnumerable<ILine> IPolygon.Edges
        {
            get { return (IList<ILine>)this._Edges; }
        }

        IEnumerable<IVector> IPolygon.Verticies
        {
            get { return this.Verticies; }
        }
        
        private float CalculateArea()
        {
            return this.Area;
        }

        private void SortEdges()
        {
            for (int i = 0; i < this._Edges.Count() - 1; i++)
            {
                for (int j = i + 1; j < this._Edges.Count(); j++)
                {
                    if (this._Edges[j].Start == this._Edges[i].End)
                    {
                        var swap = this._Edges[i + 1];
                        this._Edges[i + 1] = this._Edges[j];
                        this._Edges[j] = swap;
                        break;
                    }
                }
            }
            this.EdgesSorted = true;
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

        private void _Edges_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InitializeValues();
        }

        private void InitializeValues()
        {
            this._Center = null;
            this._Area = -1;
            this._Radius = -1;
            this.EdgesSorted = false;
            this.VerticesFound = false;
        }

        internal static Vector FindCenter(IEnumerable<Vector> verticies, float area)
        {
            var v = verticies.ToList();
            var centroid = new Vector(0, 0);
            for (int i = 0; i < v.Count() - 1; i++)
            {
                var tmp = ((v[i].X * v[i + 1].Y) - (v[i + 1].X * v[i].Y));
                centroid.X += (v[i].X + v[i + 1].X) * tmp;
                centroid.Y += (v[i].Y + v[i + 1].Y) * tmp;
            }
            return centroid.Divide(6*area);
        }

        internal static Vector FindCenter(IEnumerable<Vector> verticies)
        {
            return FindCenter(verticies, FindArea(verticies));
        }

        internal static float FindArea(IEnumerable<Vector> verticies)
        {
            var v = verticies.ToList();
            var points = v.Count();

            float area = 0.0f;
            int i, j = points - 1;
            IVector pointI, pointJ;

            for (i = 0; i < points; i++)
            {
                pointI = v[i];
                pointJ = v[j];
                area += (pointJ.X + pointI.X) * (pointJ.Y - pointI.Y);
                j = i;
            }

            return area * .5f;
        }
    }
}
