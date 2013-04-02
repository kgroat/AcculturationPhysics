namespace SharpPhysics.Graphics.Api.Impl
{
    using SharpPhysics.Physics.Api;
    using SharpPhysics.Physics.Api.Impl;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class RenderContext : IRenderContext
    {
        private RenderablePhysicsEnvironment __PhysicsEnvironment;

        internal ObservableCollection<ARenderable> _Renderables { get; private set; }

        internal PhysicsEnvironment _PhysicsEnvironment
        {
            get { return this.__PhysicsEnvironment; }
        }

        internal RenderContext(int width, int height, float scale)
        {
            this.__PhysicsEnvironment = new RenderablePhysicsEnvironment(this);
            this._Renderables = new ObservableCollection<ARenderable>();
            this._Renderables.CollectionChanged += _Renderables_CollectionChanged;
        }

        public IPhysicsEnvironment PhysicsEnvironment
        {
            get { return this._PhysicsEnvironment; }
        }

        public IList<ARenderable> Renderables
        {
            get { return _Renderables; }
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

            internal override IEnumerable<PhysicsObject> PhysicsObjects
            {
                get { return ctx._Renderables.Select(r => r._PhysicsObject); }
            }
        }
    }
}
