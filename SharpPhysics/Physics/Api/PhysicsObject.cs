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

        public float Z { get; set; }

        public float Mass { get; set; }

        public float Theta { get; set; }

        public Vector Velocity { get; set; }

        public float DTheta { get; set; }

        public Vector CenterOfMass
        {
            get { return this.Bounds.Center; }
            set { this.Bounds.Center = value; }
        }

        public Vector KineticEnergy
        {
            get
            {
                return Velocity * Mass;
            }
        }

        public bool Intersects(PhysicsObject other)
        {
            return this.Bounds.Intersects(other.Bounds);
        }

        public void Impulse(Line force)
        {
            var div = force / Mass;
            var cross = (CenterOfMass - force.Start).Normalize().Dot(div.Normalize());
            DTheta -= div.Length * cross / 3;
            Velocity += div * (1 - cross);
        }

        public Polygon Bounds { get; set; }
    }
}
