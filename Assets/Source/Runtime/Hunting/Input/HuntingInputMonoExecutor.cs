using System;
using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingInputMonoExecutor : MonoInputKeyCodeDownExecutor
    {
        [Inject] private readonly HuntingInputExecutor m_huntingInputExecutor = default;
        protected override BaseExecutor<ICommandVoid<Action>, Action> BaseExecutor => m_huntingInputExecutor;
    }
}