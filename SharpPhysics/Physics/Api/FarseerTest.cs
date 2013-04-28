using FarseerPhysics.Collision;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPhysics.Physics.Api
{
    public class FarseerTest
    {
        public FarseerTest()
        {
            w = new World(new Vector2(0, 1f), new AABB(new Vector2(0, 0), new Vector2(2000, 2000)));
            var body = new Body(w);
        }

        private World w;
    }
}
