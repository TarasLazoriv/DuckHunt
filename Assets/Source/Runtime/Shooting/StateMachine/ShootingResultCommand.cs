using LazerLabs.Commands;
namespace DuckHunt
{
    public interface IShootingResultCommand : ICommand {}

    public sealed class ShootingResultCommand : IShootingResultCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
