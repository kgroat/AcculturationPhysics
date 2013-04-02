namespace SharpPhysics.Graphics.Api
{
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RenderContext
    {
        private RenderablePhysicsEnvironment __PhysicsEnvironment;

        internal RenderContext(int width, int height, float scale)
        {
            var tmp = new ObservableCollection<ARenderable>();
            this.__PhysicsEnvironment = new RenderablePhysicsEnvironment(this);
            this.Renderables = tmp;
            tmp.CollectionChanged += _Renderables_CollectionChanged;
        }

        public PhysicsEnvironment PhysicsEnvironment { get; private set; }

        public IList<ARenderable> Renderables { get; private set; }

        public void Render(System.Drawing.Graphics g)
        {

        }

        private void _Renderables_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var items = e.NewItems.Cast<ARenderable>();
            foreach (var item in items)
            {
                item._IsRendered = true;
                item.CreateImageFromBounds();
                item.Render(System.Drawing.Graphics.FromImage(item._Texture));
            }
        }

        private class RenderablePhysicsEnvironment : PhysicsEnvironment
        {
            private RenderContext ctx;

            internal RenderablePhysicsEnvironment(RenderContext ctx)
            {
                this.ctx = ctx;
            }

            public override IEnumerable<PhysicsObject> PhysicsObjects
            {
                get { return ctx.Renderables.Select(r => r._PhysicsObject); }
            }
        }
    }
}
