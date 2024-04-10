using System;
using System.Collections;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public sealed class DuckExecutor : CoroutineCommandExecutor<IEnumerable<Vector2>>, ICommandVoid<IEnumerable<Vector2>>, IDuckMoveStoppable
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<IEnumerable<Vector2>, IEnumerator> Command { get; }
        protected override IEnumerable<Vector2> Target => m_target;

        private IEnumerable<Vector2> m_target = default;
        public ICoroutineStoppable Stoppable { get; }

        public DuckExecutor(IDuckCommand command, ICoroutineCommandRunner runner)
        {
            Command = command;
            Runner = runner;
            Stoppable = runner;
        }

        public void Execute(IEnumerable<Vector2> v1)
        {
            m_target = v1;
            Execute();
        }
    }
}