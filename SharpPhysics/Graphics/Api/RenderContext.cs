namespace SharpPhysics.Graphics.Api
{
    using FarseerPhysics.Dynamics;
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class RenderContext
    {
        public RenderContext(float scale = 1)
        {
            var tmp = new ObservableCollection<ARenderable>();
            this.PhysicsEnvironment = new RenderablePhysicsEnvironment(this);
            this.Renderables = tmp;
            tmp.CollectionChanged += _Renderables_CollectionChanged;
        }

        public PhysicsEnvironment PhysicsEnvironment { get; private set; }

        public IList<ARenderable> Renderables { get; private set; }

        public void Render(System.Drawing.Graphics g)
        {
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            this.RenderBackdrop(g);
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.Ground.Render(g);
            this.Renderables.Each(rend => rend.Render(g));
        }

        public abstract float Width { get; }

        public abstract float Height { get; }

        public abstract ARenderable Ground { get; }

        public abstract void RenderBackdrop(System.Drawing.Graphics g);

        private void _Renderables_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var items = e.NewItems.Cast<ARenderable>();
            foreach (var item in items)
            {
                item._IsRendered = true;
                using (var g = System.Drawing.Graphics.FromImage(item._Texture))
                {
                    item.Render(g);
                    item.ctx = this;
                }
            }
        }

        private class RenderablePhysicsEnvironment : PhysicsEnvironment
        {
            private RenderContext ctx;

            internal RenderablePhysicsEnvironment(RenderContext ctx)
            {
                this.ctx = ctx;
            }

            public override IEnumerable<Fixture> PhysicsObjects
            {
                get { return ctx.Renderables.Select(r => r._PhysicsObject); }
            }
        }
    }
}
