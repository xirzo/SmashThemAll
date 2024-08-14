using STA.Domain.Movement;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace STA.Presentation.Inputs
{
    public class PlayerInput : MonoBehaviour, IMovementInput
    {
        [SerializeField] private Camera _camera;
        private InputActions _actions;

        private void Awake()
        {
            _actions = new InputActions();
            _actions.Enable();
        }

        private void OnDestroy()
        {
            _actions.Disable();
        }

        public Vector3 GetMovement()
        {
            var input = _actions.Player.Movement.ReadValue<Vector2>();
            // TODO: Remove camera reference from Inpt
            input = _camera.ScreenToWorldPoint(input);
            return new Vector3(input.x, input.y, 0);
        }
    }
}