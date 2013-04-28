namespace SharpPhysics.Physics.Api
{
    using FarseerPhysics.Dynamics;
    using FarseerPhysics.Collision;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FarseerPhysics.Collision.Shapes;
    using Microsoft.Xna.Framework;
using FarseerPhysics.Common;

    public abstract class PhysicsEnvironment
    {
        protected World FarseerWorld { get; set; }

        internal PhysicsEnvironment() : this(new PhysicsEnvironmentSettings(), new World(new Vector2(0f, 0f))) { }

        internal PhysicsEnvironment(PhysicsEnvironmentSettings settings) : this(settings, new World(new Vector2(0f, 0f))) { }

        internal PhysicsEnvironment(PhysicsEnvironmentSettings settings, World farseerWorld)
        {
            this.Settings = settings;
            this.FarseerWorld = farseerWorld;
        }

        public PhysicsEnvironmentSettings Settings { get; protected set; }

        public abstract List<Body> PhysicsObjects { get; }

        public Body CreateBody()
        {
            return new Body(FarseerWorld);
        }

        public BreakableBody CreateBreakableBody(IEnumerable<Vertices> vertices, float density)
        {
            return new BreakableBody(vertices, FarseerWorld, density);
        }
    }
}
