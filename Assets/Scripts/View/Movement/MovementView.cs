using UnityEngine;

namespace STA.View.Movement
{
    public class MovementView : MonoBehaviour
    {
        public void Move(System.Numerics.Vector3 position)
        {
            Vector3 newPosition = new Vector3(position.X, position.Y, position.Z);
            transform.position = newPosition;
        }
    }
}