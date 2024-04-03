using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckAnimationExecutor : ObserverTargetExecutor<DuckDirection>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<DuckDirection> Command { get; }

        public DuckAnimationExecutor(IDuckAnimationCommand command, CommandRunner runner, IDuckDirectionObservable duckDirection)
        {
            Runner = runner;
            Command = command;
            duckDirection.Subscribe(this);
        }

    }
}