using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckExecutor : CoroutineExecutor
    {
        protected override ICommand<IEnumerator> Command { get; }
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }

        public DuckExecutor(IDuckCommand command, CoroutineCommandRunner runner)
        {
            Command = command;
            Runner = runner;
        }

    }
}