using SharpPhysics.Graphics.Api.Impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace SharpPhysics.Graphics.Api
{
    public class BindingContext
    {
        private object _lock;

        private RenderContext _RenderContext;

        public IntPtr? HWnd { get; private set; }

        public Window Window { get; private set; }

        public Image Image { get; private set; }

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

        public BindingContext(Window window, RenderContext RenderContext = null)
        {
            this.Window = window;
            this.Image = null;
            this.RenderContext = RenderContext;
            this.HWnd = new WindowInteropHelper(Window).Handle;
            _lock = new object();
        }

        public BindingContext(Image image, RenderContext RenderContext = null)
        {
            this.Image = image;
            this.Window = null;
            this.RenderContext = RenderContext;
            this.HWnd = null;
            _lock = new object();
        }

        public System.Drawing.Graphics CreateGraphics()
        {
            if (this.HWnd.HasValue)
            {
                return System.Drawing.Graphics.FromHwnd(this.HWnd.Value);
            }
            return System.Drawing.Graphics.FromImage(this.Image);
        }

        public void Render()
        {
            lock (this._lock)
            {
                if (this.RenderContext != null)
                {
                    this.RenderContext.Render(this.CreateGraphics());
                }
            }
        }
    }
}
