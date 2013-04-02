namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LocalPhysics
    {
        public LocalPhysics()
        {

        }

        public PhysicsEnvironmentSettings Settings { get; set; }

        public Polygon Region { get; set; }
    }
}
