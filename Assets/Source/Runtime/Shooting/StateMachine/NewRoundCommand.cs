using LazerLabs.Commands;
namespace DuckHunt
{
    public interface INewRoundCommand : ICommand {}

    public sealed class NewRoundCommand : INewRoundCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
