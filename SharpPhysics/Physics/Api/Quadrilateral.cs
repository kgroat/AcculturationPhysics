namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quadrilateral : Polygon
    {
        internal Quadrilateral(Vector point0, Vector point1, Vector point2, Vector point3)
            : base(new ObservableCollection<Vector>() { point0, point1, point2, point3 })
        {
            this._Radius = Edges.Max(e => e.Length);
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
    }
}
