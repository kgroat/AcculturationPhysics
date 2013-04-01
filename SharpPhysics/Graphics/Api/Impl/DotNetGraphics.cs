namespace SharpPhysics.Graphics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DotNetGraphics
    {
        private Graphics WrappedGraphics;

        internal DotNetGraphics(Graphics g)
        {
            this.WrappedGraphics = g;
        }

    }
}
