﻿namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPhysicsObject
    {
        IVector CenterOfMass { get; }

        float Mass { get; }

        float Z { get; }
        float Theta { get; }

        float Dx { get; }
        float Dy { get; }
        float Dz { get; }
        float DTheta { get; }

        IPolygon BoundingBox { get; }
    }
}
