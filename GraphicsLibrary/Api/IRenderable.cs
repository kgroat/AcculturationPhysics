namespace GraphicsLibrary.Api
{
    using SharpPhysics.Api;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRenderable
    {
        IPhysicsObject PhysicalPortion { get; }

        void Render(Graphics g);
    }
}
