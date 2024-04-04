using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IDuckMoveStoppable
    {
        public ICoroutineStoppable Stoppable { get; }
    }
}