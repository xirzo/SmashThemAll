
using System.Numerics;

namespace STA.Domain.Movement
{
    public class HandMovement : IMovement
    {
        public Vector3 Position => _position;
        private Vector3 _position;

        public void Move(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}