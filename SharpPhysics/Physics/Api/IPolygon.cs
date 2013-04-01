namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPolygon
    {
        IVector Center { get; }

        float Area { get; }

        IEnumerable<ILine> Edges { get; }

        IEnumerable<IVector> Verticies { get; }

        bool IsInside(IVector point);

        bool Intersects(IPolygon polygon);

        bool Intersects(ILine line);

        IPolygon Intersection(IPolygon polygon);

        IPolygon Sum(IPolygon polygon);
    }
}
