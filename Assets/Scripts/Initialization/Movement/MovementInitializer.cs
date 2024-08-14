using STA.Domain.Movement;
using STA.Presentation.Inputs;
using STA.Presentation.Movement;
using STA.View.Movement;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace STA.Initialization.Movement
{
    public class MovementInitalizer : MonoBehaviour
    {
        private enum MovementType
        {
            Hand,
            Bug
        }

        [SerializeField] private MovementType _movementType;
        [Space]
        [SerializeField] private MovementView _movementViewPrefab;
        [Space]
        [SerializeField] private PlayerInput _playerInput;
        private IMovement _movement;
        private MovementPresenter _movementPresenter;
        private MovementView _movementView;

        private void SetMovement()
        {
            switch (_movementType)
            {
                case MovementType.Hand:
                    _movement = new HandMovement(_playerInput);
                    break;

                case MovementType.Bug:
                    _movement = new BugMovement(new Vector3(0, 0, 0));
                    break;

                default:
                    _movement = new BugMovement(new Vector3(0, 0, 0));
                    break;
            }
        }

        private void InitializePresenter()
        {
            SetMovement();
            _movementView = Instantiate(_movementViewPrefab);
            _movementPresenter = new MovementPresenter(_movementView, _movement);
        }

        private void Awake()
        {
            InitializePresenter();
        }

        private void Update()
        {
            _movementPresenter.Update(Time.deltaTime);
        }
    }
}