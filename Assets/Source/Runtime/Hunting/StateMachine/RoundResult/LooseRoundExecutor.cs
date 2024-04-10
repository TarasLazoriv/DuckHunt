using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface ILooseRoundExecutor : ICommand { }
    public sealed class LooseRoundExecutor : CoroutineCommandExecutor, ILooseRoundExecutor
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<IEnumerator> Command { get; }

        public LooseRoundExecutor(CoroutineCommandRunner runner, ILooseRoundCommand command)
        {
            Runner = runner;
            Command = command;
        }
    }
}