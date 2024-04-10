using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class ShotViewExecutor : CommandObserverTargetExecutor<uint>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<uint> Command { get; }

        public ShotViewExecutor(CommandRunner runner, IShotViewCommand command, IShotAmmoObservable shotAmmoObservable)
        {
            Runner = runner;
            Command = command;
            shotAmmoObservable.Subscribe(this);
        }
    }
}