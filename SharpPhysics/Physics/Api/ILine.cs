namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILine : IVector
    {
        IVector Start { get; }

        IVector End { get; }

        bool Intersects(ILine intersector);

        IVector PointOfIntersection(ILine intersector);

        IVector PointAtSection(float t);

        ILine[] SplitAt(float t);
    }
}
