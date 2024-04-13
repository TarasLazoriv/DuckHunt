using System;
using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingInputMonoExecutor : InputKeyCodeDownExecutor
    {
        [Inject] private readonly ICommandRunner m_runner = default;
        [Inject] private readonly IHuntingInputCommand m_command = default;
        [Inject] private readonly IHuntingStateValue m_huntingState = default;
        protected override ICommandVoid<Action> Runner => m_runner;
        protected override ICommand Command => m_command;


        public override void Execute()
        {
            if (m_huntingState.Value == HuntingState.Hunting)
            {
                base.Execute();
            }
        }
    }
}