using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IWinRoundExecutor : ICommand { }
    public sealed class WinRoundExecutor : CoroutineCommandExecutor, IWinRoundExecutor
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<IEnumerator> Command { get; }

        public WinRoundExecutor(ICoroutineCommandRunner runner, IWinRoundCommand command)
        {
            Runner = runner;
            Command = command;
        }
    }
}