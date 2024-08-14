using System.Numerics;

namespace STA.Domain.Movement
{
    public class HandMovement : IMovement
    {
        public Vector3 Position => _position;
        private Vector3 _position;
        private IMovementInput _input;
        public HandMovement(IMovementInput input)
        {
            _input = input;
        }

        public void Move(float deltaTime)
        {
            _position = _input.GetMovement();
        }
    }
}