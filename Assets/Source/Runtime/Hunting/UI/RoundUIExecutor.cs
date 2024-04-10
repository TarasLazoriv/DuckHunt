using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IRoundUIExecutor : ICommand { }
    public sealed class RoundUIExecutor : CoroutineCommandExecutor, IRoundUIExecutor
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<IEnumerator> Command { get; }

        public RoundUIExecutor(CoroutineCommandRunner runner, IRoundUICommand command)
        {
            Runner = runner;
            Command = command;
        }
    }
}