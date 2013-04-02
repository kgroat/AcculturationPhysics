namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal abstract class PhysicsEnvironment : IPhysicsEnvironment
    {
        internal abstract IEnumerable<PhysicsObject> PhysicsObjects { get; }

        public float Speed { get; set; }

        internal PhysicsEnvironment()
        {
            this.Speed = 1;
        }

        IEnumerable<IPhysicsObject> IPhysicsEnvironment.PhysicsObjects
        {
            get { return this.PhysicsObjects.Select(po => (IPhysicsObject)po); }
        }

        public void Step()
        {

        }
    }
}
