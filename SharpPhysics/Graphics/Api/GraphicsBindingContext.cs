using SharpPhysics.Graphics.Api.Impl;
using SharpPhysics.Physics.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace SharpPhysics.Graphics.Api
{
    public class GraphicsBindingContext
    {
        private object _lock;

        private RenderContext _RenderContext;

        private Timer _GraphicsTimer, _PhysicsTimer;

        public IntPtr? HWnd { get; private set; }

        protected Window Window { get; private set; }

        protected Form Form { get; private set; }

        protected Image Image { get; private set; }

        public int RenderInterval
        {
            get
            {
                return this._GraphicsTimer.Interval;
            }
            set
            {
                this._GraphicsTimer.Interval = value;
            }
        }

        public int PhysicsInterval
        {
            get
            {
                return this._PhysicsTimer.Interval;
            }
            set
            {
                this._PhysicsTimer.Interval = value;
            }
        }

        public RenderContext RenderContext
        {
            get
            {
                return this._RenderContext;
            }
            set
            {
                lock (this._lock)
                {
                    this._RenderContext = value;
                }
            }
        }

        public PhysicsEnvironment PhysicsEnvironment
        {
            get
            {
                return this.RenderContext.PhysicsEnvironment;
            }
        }

        public GraphicsBindingContext(Form form, RenderContext RenderContext = null, int RenderInterval = 16, int PhysicsInterval = 16)
        {
            if (form == null)
            {
                throw new ArgumentNullException("The Form supplied was null.  BindingContext must reference either an Image or a Form.");
            }
            this.Image = null;
            this.Form = form;
            this._RenderContext = RenderContext;
            this.HWnd = this.Form.Handle;
            this._GraphicsTimer = new Timer();
            this.RenderInterval = RenderInterval;
            this._GraphicsTimer.Tick += _GraphicsTimer_Tick;
            this._PhysicsTimer = new Timer();
            this.PhysicsInterval = PhysicsInterval;
            this._PhysicsTimer.Tick +=_PhysicsTimer_Tick;
            this._lock = new object();
        }

        public GraphicsBindingContext(Image image, RenderContext RenderContext = null, int RenderInterval = 16, int PhysicsInterval = 16)
        {
            if (image == null)
            {
                throw new ArgumentNullException("The Image supplied was null.  BindingContext must reference either an Image or a Form.");
            }
            this.Image = image;
            this.Form = null;
            this._RenderContext = RenderContext;
            this.HWnd = null;
            this._GraphicsTimer = new Timer();
            this.RenderInterval = RenderInterval;
            this._GraphicsTimer.Tick += _GraphicsTimer_Tick;
            this._PhysicsTimer = new Timer();
            this.PhysicsInterval = PhysicsInterval;
            this._PhysicsTimer.Tick += _PhysicsTimer_Tick;
            this._lock = new object();
        }

        public System.Drawing.Graphics CreateGraphics()
        {
            if (this.HWnd.HasValue)
            {
                return System.Drawing.Graphics.FromHwnd(this.HWnd.Value);
            }
            return System.Drawing.Graphics.FromImage(this.Image);
        }

        public Rectangle Viewport()
        {
            if (this.Form != null)
            {
                return new Rectangle(0, 0, this.Form.Width, this.Form.Height);
            }
            return new Rectangle(0, 0, this.Image.Width, this.Image.Height);
        }

        public bool Start()
        {
            var ret = true;
            if (this._GraphicsTimer.Enabled || this._PhysicsTimer.Enabled)
            {
                ret = false;
            }
            this._GraphicsTimer.Enabled = true;
            this._PhysicsTimer.Enabled = true;
            return ret;
        }

        public bool Stop()
        {
            var ret = false;
            if (this._GraphicsTimer.Enabled || this._PhysicsTimer.Enabled)
            {
                ret = true;
            }
            this._GraphicsTimer.Enabled = false;
            this._PhysicsTimer.Enabled = false;
            return ret;
        }

        public void Render()
        {
            lock (this._lock)
            {
                if (this.RenderContext != null)
                {
                    using (var g = this.CreateGraphics())
                    {
                        this.RenderContext.Render(g);
                    }
                }
            }
        }

        private void _GraphicsTimer_Tick(object sender, EventArgs e)
        {
            this.Render();
        }

        private void _PhysicsTimer_Tick(object sender, EventArgs e)
        {
            this.PhysicsEnvironment.Step();
        }
    }
}
