using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckAnimationExecutor : CommandObserverTargetExecutor<DuckDirection>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<DuckDirection> Command { get; }

        public DuckAnimationExecutor(IDuckAnimationCommand command, ICommandRunner runner, IDuckDirectionObservable duckDirection)
        {
            Runner = runner;
            Command = command;
            duckDirection.Subscribe(this);
        }

    }
}