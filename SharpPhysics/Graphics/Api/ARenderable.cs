namespace SharpPhysics.Graphics.Api
{
    using SharpPhysics.Physics.Api;
    using System.Drawing;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ARenderable
    {
        private Image __Texture;

        private Vector __TextureOffset, __TextureScale, __TextureSize;

        private bool __IsRendered;

        internal PhysicsObject _PhysicsObject { get; set; }

        internal Image _Texture
        {
            get { return this.__Texture; }
        }

        internal Vector _TextureOffset
        {
            get { return this.__TextureOffset; }
        }

        internal Vector _TextureScale
        {
            get { return this.__TextureScale; }
        }

        internal Vector _TextureSize
        {
            get { return this.__TextureSize; }
        }

        internal bool _IsRendered
        {
            get
            {
                return __IsRendered;
            }
            set
            {
                __IsRendered = value || __IsRendered;
            }
        }

        internal RenderContext ctx { get; set; }

        public ARenderable(PhysicsObject PhysicsObject)
        {
            __TextureOffset = new Vector(0, 0);
            __TextureScale = new Vector(1, 1);
            __IsRendered = false;
            _PhysicsObject = (PhysicsObject)PhysicsObject;
            __Texture = new Bitmap(Width, Height);
        }

        public Vector TextureOffset
        {
            get
            {
                return this.__TextureOffset;
            }
            set
            {
                if (__IsRendered)
                {
                    throw new InvalidOperationException("TextureOffset cannot be changed after a Renderable object has been rendered.");
                }
                this.__TextureOffset = (Vector)value;
            }
        }

        public Vector TextureScale
        {
            get
            {
                return this.__TextureScale;
            }
            set
            {
                if (__IsRendered)
                {
                    throw new InvalidOperationException("TextureScale cannot be changed after a Renderable object has been rendered.");
                }
                this.__TextureScale = (Vector)value;
                this.__TextureSize = new Vector(Width * __TextureScale.X, Height * __TextureScale.Y);
            }
        }

        public Vector TextureSize
        {
            get
            {
                return this.__TextureSize;
            }
        }

        public int Width
        {
            get
            {
                return (int)Bounds.BoundingRect.Width + 1;
            }
        }

        public int Height
        {
            get
            {
                return (int)Bounds.BoundingRect.Height + 1;
            }
        }

        public PhysicsObject PhysicsObject
        {
            get
            {
                return this._PhysicsObject;
            }
        }

        public Polygon Bounds
        {
            get
            {
                return this._PhysicsObject.Bounds.Rotate(this._PhysicsObject.CenterOfMass, this._PhysicsObject.Theta);
            }
            set
            {
                this._PhysicsObject.Bounds = value;
            }
        }

        public abstract void Render(Graphics graphics);

        public void Put(Graphics g)
        {
            g.Transform = new System.Drawing.Drawing2D.Matrix();
            g.Transform.RotateAt(this.PhysicsObject.Theta, this.Bounds.Center.ToPoint());
        }
    }
}
