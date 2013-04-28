using SharpPhysics;
using SharpPhysics.Graphics.Api;
using SharpPhysics.Physics.Api;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForms
{
    public class FunkyRenderContext : RenderContext
    {
        private Form _Form;

        private static Brush _Backdrop = new SolidBrush(Color.FromArgb(32, 32, 32));

        private ARenderable _Ground; 

        public FunkyRenderContext(Form Form) : base()
        {
            this._Form = Form;
            this._Form.SizeChanged +=_Form_SizeChanged;
            this._Ground = FunkyPoly.CreateRectangle(0, Form.Height * 4 / 5f, Form.Width, Form.Height / 5f);
        }

        public override ARenderable Ground
        {
            get
            {
                return this._Ground;
            }
        }

        public override void RenderBackdrop(System.Drawing.Graphics g)
        {
            g.FillRectangle(_Backdrop, 0, 0, this.Width, this.Height);
        }

        public override float Width
        {
            get { return this._Form.Width; }
        }

        public override float Height
        {
            get { return this._Form.Height; }
        }

        private void _Form_SizeChanged(object sender, EventArgs e)
        {
            this._Ground = FunkyPoly.CreateRectangle(0, _Form.Height * 4 / 5f, _Form.Width, _Form.Height / 5f);
        }
    }
}
