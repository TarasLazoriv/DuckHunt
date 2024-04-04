using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckFallExecutor : ObserverTargetExecutor<int>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<int> Command { get; }

        public DuckFallExecutor(CommandRunner runner, IDuckFallCommand command, IShotDuckObservable shotDuckObservable)
        {
            Runner = runner;
            Command = command;
            shotDuckObservable.Subscribe(this);
        }
    }
}
