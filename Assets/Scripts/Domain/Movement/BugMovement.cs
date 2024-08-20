using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace STA.Domain.Movement
{
    public class BugMovement : MonoBehaviour
    {
        [SerializeField, Min(0)] private float _movementSpeed = 5f;
        [SerializeField, Min(0)] private float _movementSpeedMultiplier = 1f;
        [Space]
        [SerializeField, Min(0)] private float _attackAlertDistance = 5f;
        [SerializeField, Min(0)] private float _runningTime = 1f;
        private Vector2 _movementDirection;
        private bool _isRunning;
        private float _speed;
        private Random _random = new Random();

        private void OnEnable()
        {
            _speed = _movementSpeed;
            SetRandomDirection();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(_movementDirection * _speed * Time.deltaTime);
        }

        private void ChangeDirectionFromPosition(Vector2 attackPosition)
        {
            if (Vector3.Distance(transform.position, (Vector3)attackPosition) <= _attackAlertDistance)
            {
                if (_isRunning == true)
                    return;

                _isRunning = true;
                StartCoroutine(ChangeSpeedForSeconds());
            }
        }

        private void SetRandomDirection()
        {
            _movementDirection = new Vector2((float)_random.NextDouble(-1.0, 1.0), (float)_random.NextDouble(-1.0, 1.0));
        }

        private void ChangeDirection(Vector3 objectNormal)
        {
            _movementDirection = Vector2.Reflect(_movementDirection, objectNormal);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ChangeDirection(collision.contacts[0].normal);
        }

        private IEnumerator ChangeSpeedForSeconds()
        {
            _speed *= _movementSpeedMultiplier;
            yield return new WaitForSeconds(_runningTime);
            _speed = _movementSpeed;
            _isRunning = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackAlertDistance);
        }
    }
}
