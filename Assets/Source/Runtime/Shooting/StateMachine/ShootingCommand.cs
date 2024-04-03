using LazerLabs.Commands;
namespace DuckHunt
{
    public interface IShootingCommand : ICommand {}

    public sealed class ShootingCommand : IShootingCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
