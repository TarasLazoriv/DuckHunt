using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class HuntingInputExecutor : DefaultExecutor
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommand Command { get; }

        public HuntingInputExecutor(CommandRunner runner, IHuntingInputCommand command)
        {
            Runner = runner;
            Command = command;
        }
    }
}