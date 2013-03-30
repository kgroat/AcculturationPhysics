namespace SharpPhysics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Polygon : IPolygon
    {
        internal IVector Center { get; set; }

        internal float Area { get; set; }

        internal IList<ILine> Edges { get; set; }

        internal IList<IVector> Verticies { get; set; }

        IVector IPolygon.Center
        {
            get { return this.Center; }
        }

        float IPolygon.Area
        {
            get { return this.Area; }
        }

        IList<ILine> IPolygon.Edges
        {
            get { return this.Edges; }
        }

        IList<IVector> IPolygon.Verticies
        {
            get { return this.Verticies; }
        }

        public bool IsInside(IVector point)
        {
            throw new NotImplementedException();
        }
        
        private float CalculateArea()
        {
            var vertices = this.Verticies;
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
    }
}
