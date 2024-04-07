using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class TopScoreExecutor : DefaultExecutor
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommand Command { get; }

        public TopScoreExecutor(ICommandVoid<Action> runner, ITopScoreCommand command)
        {
            Runner = runner;
            Command = command;
        }
    }
}