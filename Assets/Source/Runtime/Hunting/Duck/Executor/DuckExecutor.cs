using System;
using System.Collections;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public sealed class DuckExecutor : CoroutineTargetExecutor<IEnumerable<Vector2>>, ICommandVoid<IEnumerable<Vector2>>
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<IEnumerable<Vector2>, IEnumerator> Command { get; }
        protected override IEnumerable<Vector2> Target => m_target;

        private IEnumerable<Vector2> m_target = default;

        public DuckExecutor(IDuckCommand command, CoroutineCommandRunner runner)
        {
            Command = command;
            Runner = runner;
        }

        public void Execute(IEnumerable<Vector2> v1)
        {
            m_target = v1;
        }
    }
}