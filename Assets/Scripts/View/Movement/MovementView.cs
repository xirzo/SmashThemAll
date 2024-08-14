using STA.Domain.Movement;
using UnityEngine;

namespace STA.View.Movement
{
    public class MovementView : MonoBehaviour
    {
        private IMovement _movement;

        public void Initialize(IMovement movement)
        {
            _movement = movement;
        }

        private void Move()
        {
            _movement.Move(Time.deltaTime);
            Vector3 newPosition = new Vector3(_movement.Position.X, _movement.Position.Y, _movement.Position.Z);
            transform.position = newPosition;
        }

        private void Update()
        {
            Move();
        }
    }
}