namespace SharpPhysics.Api
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

        IList<ILine> Edges { get; }

        IList<IVector> Verticies { get; }

        bool IsInside(IVector point);
    }
}
