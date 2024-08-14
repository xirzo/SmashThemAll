using System.Numerics;

namespace STA.Domain.Movement
{
    public interface IMovementInput
    {
        Vector3 GetMovement();
    }
}