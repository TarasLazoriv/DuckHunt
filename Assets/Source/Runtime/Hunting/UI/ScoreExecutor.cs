using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class ScoreExecutor : CommandObserverTargetExecutor<uint>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<uint> Command { get; }

        public ScoreExecutor(CommandRunner runner, IScoreCommand command, IObservablePlayerScore observable)
        {
            Runner = runner;
            Command = command;
            observable.Subscribe(this);
        }
    }
}