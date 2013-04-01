namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Polygon : IPolygon
    {
        private Vector _Center;

        private float _Area;

        private ObservableCollection<Line> _Edges;

        private bool EdgesSorted;

        private float _Radius;

        internal Polygon(IEnumerable<Line> Edges)
        {

            this._Edges = new ObservableCollection<Line>(Edges);
            this._Edges.CollectionChanged += Edges_CollectionChanged;
            this._Center = FindCenter(Verticies);
            this.EdgesSorted = false;
            this._Radius = -1;
            this.SortEdges();
            this._Area = this.CalculateArea();
        }

        internal float Radius
        {
            get
            {
                if (this._Radius <= 0)
                {
                    this._Radius = _Edges.Max(edge => (edge.End - this._Center).Length);
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
                    this._Center = FindCenter(this.Verticies);
                }
                return this._Center;
            }
            set
            {
                if (this._Center == null)
                {
                    this._Center = FindCenter(this.Verticies);
                }

                if (this._Center != value)
                {
                    SortEdges();
                    var change = value - _Center;
                    this._Center = value;
                    int j = _Edges.Count() - 1;
                    for (int i = 0; i < _Edges.Count(); i++)
                    {
                        _Edges[j].Start = (_Edges[i].End += change);
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
                    this._Area = this.CalculateArea();
                }
                return _Area;
            }
        }

        internal Collection<Line> Edges
        {
            get
            {
                return _Edges;
            }
        }

        internal IEnumerable<Vector> Verticies
        {
            get
            {
                return _Edges.Select(edge => edge.End);
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
            var vertices = this.Verticies.ToList();
            var points = vertices.Count();

            float  area=0.0f;
            int i, j=points-1;
            IVector pointI, pointJ;

            for (i=0; i<points; i++) {
                pointI = vertices[i];
                pointJ = vertices[j];
                area+=(pointJ.X+pointI.X)*(pointJ.Y-pointI.Y);
                j=i; 
            }

            return Math.Abs(area)*.5f;
        }

        private void SortEdges()
        {
            if (!this.EdgesSorted)
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
        }

        private static Vector FindCenter(IEnumerable<Vector> verticies)
        {
            var centroid = new Vector(0, 0);
            centroid = verticies.Aggregate(centroid, (center, vertex) => center += vertex);
            return centroid.Divide(verticies.Count());
        }

        public bool IsInside(IVector point)
        {
            if ((_Center - point).Length > Radius) return false;
            var lineOfIntersection = new Line((Vector)point, new Vector(Radius, Radius) + point);
            int intersectionCount = _Edges.Count(edge => edge.Intersects(lineOfIntersection));
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

        public IPolygon Difference(IPolygon polygon)
        {
            throw new NotImplementedException();
        }

        private void Edges_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this._Center = null;
            this._Area = -1;
            this.EdgesSorted = false;
            this._Radius = -1;
        }
    }
}
