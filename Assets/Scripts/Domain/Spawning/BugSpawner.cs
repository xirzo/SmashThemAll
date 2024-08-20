using STA.Domain.Movement;
using UnityEngine;

namespace STA.Domain.Spawning
{
    public class BugSpawner : MonoBehaviour
    {
        [SerializeField] private BugMovement _bugPrefab;

        private BugMovement Spawn()
        {
            return Instantiate(_bugPrefab, transform.position, Quaternion.identity);
        }

        private void Awake()
        {
            Spawn();
        }
    }
}
