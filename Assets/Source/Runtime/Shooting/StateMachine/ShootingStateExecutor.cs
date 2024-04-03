using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class ShootingStateExecutor : ObserverExecutor
    {
        private ICommand m_command;
        public ShootingStateExecutor(ICommandVoid<Action> runner)
        {
        }

        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommand Command { get; }
    }
}
