namespace SharpPhysics.Physics.Api
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhysicsObject
    {
        public PhysicsObject()
        {

        }

        public float Z { get; internal set; }

        public float Mass { get; internal set; }

        public float Theta { get; internal set; }

        public Vector Velocity { get; internal set; }

        public float DTheta { get; internal set; }

        public Vector CenterOfMass
        {
            get { return this.Bounds.Center; }
            set { this.Bounds.Center = value; }
        }

        public Polygon Bounds { get; protected set; }
    }
}
