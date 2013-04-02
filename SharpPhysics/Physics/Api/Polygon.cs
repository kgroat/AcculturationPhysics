namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Polygon
    {
        protected Vector _Center { get; set; }

        protected float _SignedArea { get; set; }

        protected float _Area { get; set; }

        protected IList<Line> _Edges { get; set; }

        protected bool EdgesSorted { get; set; }

        protected bool VerticesFound { get; set; }

        protected float _Radius { get; set; }

        protected IList<Vector> _Verticies { get; set; }

        protected Polygon() { }

        public Polygon(IEnumerable<Line> Edges)
        {
            var tmp = new ObservableCollection<Line>(Edges);
            this._Edges = tmp;
            tmp.CollectionChanged += _Edges_CollectionChanged;
            this.InitializeValues();
            this.SortEdges();
        }

        public Polygon(IList<Vector> Verticies)
        {
            this._Verticies = Verticies;
            var tmp = new ObservableCollection<Line>();
            for (int i = 0; i < Verticies.Count()-1; i++)
            {
                tmp.Add(new Line(Verticies[i], Verticies[i + 1]));
            }
            tmp.Add(new Line(Verticies[Verticies.Count() - 1], Verticies[0]));
            this._Edges = tmp;
            tmp.CollectionChanged += _Edges_CollectionChanged;
            this.InitializeValues();
            this.SortEdges();
        }

        public virtual float Radius
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

        public virtual Vector Center
        {
            get
            {
                if (this._Center == null)
                {
                    this._Center = FindCenter(this.Verticies, this.Area);
                }
                return this._Center;
            }
            internal set
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

        public virtual float Area
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

        public virtual float SignedArea
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

        public virtual IList<Line> Edges
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

        public virtual IList<Vector> Verticies
        {
            get
            {
                if (!this.VerticesFound)
                {
                    this._Verticies = this._Edges.Select(edge => edge.End).ToList();
                    this.VerticesFound = true;
                }
                return this._Verticies;
            }
        }

        public virtual RectanglePoly BoundingRect { get; protected set; }

        public virtual bool IsInside(Vector point)
        {
            if ((Center - point).Length > Radius) return false;
            var lineOfIntersection = new Line((Vector)point, new Vector(Radius, Radius) + point);
            int intersectionCount = Edges.Count(edge => edge.Intersects(lineOfIntersection));
            return (intersectionCount % 2) == 1;
        }

        public virtual bool Intersects(Polygon polygon)
        {
            if (polygon.Verticies.Any(vertex => this.IsInside(vertex)))
            {
                return true;
            }
            return polygon.Edges.Any(edge => this.Intersects(edge));
        }

        public virtual bool Intersects(Line line)
        {
            return _Edges.Any(edge => edge.Intersects(line));
        }

        public virtual Polygon Intersection(Polygon polygon)
        {
            throw new NotImplementedException();
        }

        public virtual Polygon Sum(Polygon polygon)
        {
            throw new NotImplementedException();
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
            Vector pointI, pointJ;

            for (i = 0; i < points; i++)
            {
                pointI = v[i];
                pointJ = v[j];
                area += (pointJ.X + pointI.X) * (pointJ.Y - pointI.Y);
                j = i;
            }

            return area * .5f;
        }

        protected virtual void _Edges_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InitializeValues();
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

        private void InitializeValues()
        {
            this._Center = null;
            this._Area = -1;
            this._Radius = -1;
            this.EdgesSorted = false;
            this.VerticesFound = false;
        }
    }
}
