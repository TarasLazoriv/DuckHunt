using System;
using System.Collections;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckMonoExecutor : CoroutineMonoExecutor, ICommandVoid<IEnumerable<Vector2>>
    {
        public sealed class Factory : PlaceholderFactory<DuckMonoExecutor> { }

        [Inject] private readonly DuckExecutor m_duckExecutor = default;


        protected override BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>> BaseExecutor => m_duckExecutor;

        public void Execute(IEnumerable<Vector2> v1)
        {
            m_duckExecutor.Execute(v1);
            Execute();
        }
    }
}
