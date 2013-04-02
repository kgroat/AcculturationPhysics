namespace SharpPhysics.Graphics.Api
{
    using SharpPhysics.Physics.Api;
    using SharpPhysics.Physics.Api.Impl;
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

        private int __Width, __Height;

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

        internal int _Width
        {
            get
            {
                return __Width;
            }
        }

        internal int _Height
        {
            get
            {
                return __Height;
            }
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

        public ARenderable(IPhysicsObject PhysicsObject)
        {
            __Width = __Height = 100;
            __TextureOffset = new Vector(0, 0);
            __TextureScale = new Vector(1, 1);
            __IsRendered = false;
            _PhysicsObject = (PhysicsObject)PhysicsObject;
        }

        public IVector TextureOffset
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

        public IVector TextureScale
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
                this.__TextureSize = new Vector(__Width * __TextureScale.X, __Height * __TextureScale.Y);
            }
        }

        public IVector TextureSize
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
                return this.__Width;
            }
            set
            {
                if (__IsRendered)
                {
                    throw new InvalidOperationException("Width cannot be changed after a Renderable object has been rendered.");
                }
                this.__Width = value;
                this.__TextureSize = new Vector(__Width * __TextureScale.X, __Height * __TextureScale.Y);
            }
        }

        public int Height
        {
            get
            {
                return this.__Height;
            }
            set
            {
                if (__IsRendered)
                {
                    throw new InvalidOperationException("Height cannot be changed after a Renderable object has been rendered.");
                }
                this.__Height = value;
                this.__TextureSize = new Vector(__Width * __TextureScale.X, __Height * __TextureScale.Y);
            }
        }

        public IPhysicsObject PhysicsObject
        {
            get
            {
                return this._PhysicsObject;
            }
        }

        public abstract void Render(Graphics graphics);

        internal void CreateImageFromBounds()
        {
            __Texture = new Bitmap(__Width, __Height);
        }
    }
}
