using System;
using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public interface ISpawnCommand : ICommand { }

    public sealed class SpawnCommand : ISpawnCommand
    {
        //[Inject] private readonly IGetRandomSpawnPointCommand m_getRandomSpawnPoint = default;
        //[Inject] private readonly DuckMovementExecutor.Factory m_factory = default;


        public void Execute()
        {
            //DuckMovementExecutor element = m_factory.Create();
        }
    }
    

    public sealed class DuckMovementExecutor : DefaultExecutor
    {
        public sealed class Factory : PlaceholderFactory<DuckMovementExecutor> { }

        public DuckMovementExecutor(ICommand command, ICommandVoid<Action> runner) : base(command, runner)
        {
        }
    }
}
