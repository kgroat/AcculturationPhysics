namespace SharpPhysics.Graphics.Api
{
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRenderContext
    {
        IPhysicsEnvironment PhysicsEnvironment { get; }

        IList<ARenderable> Renderables { get; }
    }
}
