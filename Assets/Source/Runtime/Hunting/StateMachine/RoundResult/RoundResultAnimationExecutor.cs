using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IRoundResultAnimationExecutor : ICommandVoid<ICommand> { }
    public sealed class RoundResultAnimationExecutor : CoroutineCommandExecutor<ICommand>, IRoundResultAnimationExecutor
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<ICommand, IEnumerator> Command { get; }
        protected override ICommand Target => m_target;

        private ICommand m_target = default;

        public RoundResultAnimationExecutor(ICoroutineCommandRunner runner, IRoundResultAnimationCommand command)
        {
            Runner = runner;
            Command = command;
        }

        public void Execute(ICommand target)
        {
            m_target = target;
            Execute();
        }
    }
}