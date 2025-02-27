using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckFallExecutor : CommandObserverTargetExecutor<int>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<int> Command { get; }

        public DuckFallExecutor(ICommandRunner runner, IDuckShotDownCommand command, IShotDuckObservable shotDuckObservable)
        {
            Runner = runner;
            Command = command;
            shotDuckObservable.Subscribe(this);
        }
    }
}
