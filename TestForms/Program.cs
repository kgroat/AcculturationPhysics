using SharpPhysics;
using SharpPhysics.Graphics.Api;
using SharpPhysics.Physics.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BindContext = SharpPhysics.Graphics.Api.GraphicsBindingContext;

namespace TestForms
{
    public static class Program
    {
        public static Form form { get; set; }

        public static BindContext bind { get; set; }

        public static RenderContext render { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new TestForm();
            render = new FunkyRenderContext(form);
            bind = new GraphicsBindingContext(form, RenderContext: render);
            render.Renderables.Add(FunkyPoly.CreateRectangle(100, 500, 50, 50, velocity: new Vector(2, -1), dTheta: .9f));
            bind.Start();
            Application.Run(form);
        }
    }
}
