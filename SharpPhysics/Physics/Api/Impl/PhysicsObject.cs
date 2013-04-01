namespace SharpPhysics.Physics.Api.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PhysicsObject : IPhysicsObject
    {
        private Polygon _BoundingBox;

        private float _Z, _Mass, _Theta, _Dx, _Dy, _Dz, _DTheta;

        IVector IPhysicsObject.CenterOfMass
        {
            get { return this._BoundingBox.Center; }
        }

        float IPhysicsObject.Z
        {
            get { return this._Z; }
        }

        float IPhysicsObject.Mass
        {
            get { return this._Mass; }
        }

        float IPhysicsObject.Theta
        {
            get { return this._Theta; }
        }

        float IPhysicsObject.Dx
        {
            get { return this._Dx; }
        }

        float IPhysicsObject.Dy
        {
            get { return this._Dy; }
        }

        float IPhysicsObject.Dz
        {
            get { return this._Dz; }
        }

        float IPhysicsObject.DTheta
        {
            get { return this._DTheta; }
        }

        IPolygon IPhysicsObject.BoundingBox
        {
            get { return this._BoundingBox; }
        }
    }
}
