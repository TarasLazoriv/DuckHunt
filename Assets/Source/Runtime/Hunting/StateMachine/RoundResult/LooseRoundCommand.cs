using LazerLabs.Commands;
namespace DuckHunt
{
    public interface ILooseRoundCommand : ICommand {}

    public sealed class LooseRoundCommand : ILooseRoundCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }


}
