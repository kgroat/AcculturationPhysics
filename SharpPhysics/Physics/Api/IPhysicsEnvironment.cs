namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPhysicsEnvironment
    {
        IEnumerable<IPhysicsObject> PhysicsObjects { get; }

        float Speed { get; set; }

        void Step();
    }
}
