using LazerLabs.Commands;
namespace DuckHunt
{
    public interface IFirstRoundIntroCommand : ICommand {}

    public sealed class FirstRoundIntroCommand : IFirstRoundIntroCommand
    {
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
