using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class HuntingInputExecutor : DefaultExecutor
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommand Command { get; }

        private readonly IHuntingStateValue m_huntingState = default;

        public HuntingInputExecutor(CommandRunner runner, IHuntingInputCommand command, IHuntingStateValue huntingState)
        {
            Runner = runner;
            Command = command;
            m_huntingState = huntingState;
        }

        public override void Execute()
        {
            if (m_huntingState.Value == HuntingState.Hunting)
            {
                base.Execute();
            }
        }
    }
}