using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class RoundDuckGoalExecutor : CommandObserverTargetExecutor<uint>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<uint> Command { get; }

        public RoundDuckGoalExecutor(CommandRunner runner, IRoundDuckGoalCommand command, IRoundGoalObservable observable)
        {
            Runner = runner;
            Command = command;
            observable.Subscribe(this);
        }
    }
}