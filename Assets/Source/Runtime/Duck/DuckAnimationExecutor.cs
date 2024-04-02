using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckAnimationExecutor : ObservableTargetExecutor<DuckDirection>
    {
        public DuckAnimationExecutor(IDuckAnimationCommand command, CommandRunner runner, IDuckDirectionObservable duckDirection) : base(command, runner)
        {
            Subscribe(duckDirection);
        }
    }
}