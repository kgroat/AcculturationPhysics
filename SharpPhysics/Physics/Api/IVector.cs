namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVector
    {
        float X { get; }

        float Y { get; }

        float Length { get; }

        IVector Add(IVector addend);

        IVector Subtract(IVector subtrahend);

        float Dot(IVector other);

        IVector Multiply(float multiplicand);

        IVector Divide(float dividend);

        IVector Normalize();

        PointF ToPoint();

        SizeF ToSize();
    }
}
