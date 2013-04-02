namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class PhysicsEnvironment
    {
        internal PhysicsEnvironment()
        {
            this.Settings = new PhysicsEnvironmentSettings();
        }

        internal PhysicsEnvironment(PhysicsEnvironmentSettings settings)
        {
            this.Settings = settings;
        }

        public PhysicsEnvironmentSettings Settings { get; set; }

        public abstract IEnumerable<PhysicsObject> PhysicsObjects { get; }

        public void Step()
        {
            foreach (var obj in this.PhysicsObjects)
            {
                obj.Velocity += Settings.Gravity * Settings.Speed;
                obj.CenterOfMass += obj.Velocity * Settings.Speed;
            }
        }
    }
}
