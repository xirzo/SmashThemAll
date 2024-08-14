using System.Numerics;

namespace STA.Domain.Movement
{
    public class BugMovement : IMovement
    {
        public Vector3 Position => _position;
        private Vector3 _position;
        private Vector3 _direction;
        private Vector3 _velocity;
        private float _speed = 5f;

        public BugMovement(Vector3 startPosition)
        {
            _position = startPosition;

            // ! Should be replaced with ai choose of direction 
            _direction = new Vector3(1, 0, 0);
        }

        private void CalculateVelocity(float deltaTime)
        {
            _velocity = Vector3.Normalize(_direction) * _speed * deltaTime;
        }

        public void Move(float deltaTime)
        {
            CalculateVelocity(deltaTime);
            _position += _velocity;
        }
    }
}