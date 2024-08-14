using STA.Domain.Movement;
using STA.View.Movement;

namespace STA.Presentation.Movement
{
    public class MovementPresenter
    {
        private MovementView _movementView;
        private IMovement _movement;

        public MovementPresenter(MovementView movementView, IMovement movement)
        {
            _movementView = movementView;
            _movement = movement;
        }

        private void Move(float deltaTime)
        {
            _movement.Move(deltaTime);
            _movementView.Move(_movement.Position);
        }

        public void Update(float deltaTime)
        {
            Move(deltaTime);
        }
    }
}