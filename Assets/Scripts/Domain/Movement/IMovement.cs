using System.Numerics;

namespace STA.Domain.Movement
{
    public interface IMovement
    {
        Vector3 Position { get; }
        void Move(float deltaTime);
    }
}
