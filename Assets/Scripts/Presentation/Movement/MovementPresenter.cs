using System;
using STA.Domain.Movement;
using STA.View.Movement;
using UnityEngine;

namespace STA.Presentation.Movement
{
    public class MovementPresenter : MonoBehaviour
    {
        private enum MovementType
        {
            Hand,
            Bug
        }

        [SerializeField] private MovementType _movementType;
        [Space]
        [SerializeField] private MovementView _movementViewPrefab;
        private IMovement _movement;
        private MovementView _movementView;

        private void SetMovement()
        {
            switch (_movementType)
            {
                case MovementType.Hand:
                    _movement = new HandMovement();
                    break;

                case MovementType.Bug:
                    _movement = new BugMovement();
                    break;
                default:
                    _movement = new BugMovement();
                    break;
            }
        }

        private void InstantiateViewAndInitialize()
        {
            if (_movement == null)
                throw new NullReferenceException("Cannot initialize movement view without movement!");

            _movementView = Instantiate(_movementViewPrefab);
            _movementView.Initialize(_movement);
        }

        private void Awake()
        {
            SetMovement();
            InstantiateViewAndInitialize();
        }
    }
}