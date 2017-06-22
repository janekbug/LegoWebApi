using System.Threading.Tasks;

namespace LegoMindstorms.BL.Movement
{
    public interface IMovementService
    {
        Task MoveForward();
        Task Stop();
        Task MoveBackward();
        Task TurnLeft();
        Task TurnRight();
    }
}
