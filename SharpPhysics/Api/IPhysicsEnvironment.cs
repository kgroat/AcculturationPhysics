namespace SharpPhysics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPhysicsEnvironment
    {
        IList<IPhysicsObject> PhysicsObjects { get; }
    }
}
