namespace TestForms
{
    using SharpPhysics;
    using SharpPhysics.Graphics.Api;
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FunkyPoly : ARenderable
    {
        private static Random rand
        {
            get
            {
                return GraphicsHelper.Rand;
            }
        }

        private Brush Brush;

        private FunkyPoly(PhysicsObject phys, Brush Brush)
            : base(phys)
        {
            this.Brush = Brush;
        }

        public override void Render(System.Drawing.Graphics graphics)
        {
            graphics.FillPolygon(this.Brush, this.Bounds);
        }

        public static FunkyPoly CreateRandomShape(int sides = -1, int minSides = 3, int maxSides = 30, float minX = 0, float minY = 0, float maxX = 500, float maxY = 500, Brush brush = null)
        {
            if (sides < 3)
            {
                sides = rand.Next(maxSides - minSides) + minSides;
            }
            var points = new List<Vector>();
            for (int i = 0; i < sides; i++)
            {
                points.Add(new Vector((float)(rand.NextDouble() * (maxX - minX) + minX), (float)(rand.NextDouble() * (maxY - minY) + minY)));
            }

            var phys = new PhysicsObject
            {
                Bounds = new Polygon(points),
                Mass = 100,
                Velocity = new Vector(1, 1),
                Theta = 0,
                DTheta = .01f
            };

            if(brush == null)
            {
                brush = new SolidBrush(GraphicsHelper.RandomColor());
            }

            return new FunkyPoly(phys, brush);
        }
        
        public static FunkyPoly CreateRectangle(float x, float y, float width, float height, Brush brush = null, Vector velocity = null, float dTheta = 0, float theta = 0, float mass = 100)
        {
            if (velocity == null)
            {
                velocity = new Vector();
            }
            var phys = new PhysicsObject
            {
                Bounds = new RectanglePoly(x, y, width, height),
                Mass = mass,
                Velocity = velocity,
                Theta = theta,
                DTheta = dTheta
            };

            if (brush == null)
            {
                brush = new SolidBrush(GraphicsHelper.RandomColor());
            }

            return new FunkyPoly(phys, brush);
        }
    }
}
