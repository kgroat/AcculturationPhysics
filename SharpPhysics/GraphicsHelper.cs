namespace SharpPhysics
{
    using SharpPhysics.Graphics.Api;
    using SharpPhysics.Graphics.Api.Impl;
    using SharpPhysics.Physics.Api;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Interop;

    public static class GraphicsHelper
    {
        private static Random _Rand = new Random();

        public static Random Rand
        {
            get
            {
                return _Rand;
            }
        }

        public static PhysicsEnvironmentSettings DefaultPhysicsSettings
        {
            get { return new PhysicsEnvironmentSettings(); }
        }

        public static Color RandomColor(int high = 255, int low = 0, int alpha = 255)
        {
            int[] rgb = new int[3];
            int h, l;
            h = Rand.Next(3);
            l = Rand.Next(3);
            while (l == h) { l = Rand.Next(3); }
            rgb[h] = high;
            rgb[l] = low;
            rgb[3 - (h + l)] = Rand.Next(high - low) + low;
            return Color.FromArgb(alpha, rgb[0], rgb[1], rgb[2]);
        }
    }
}
