using System;
using System.Collections;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckMonoExecutor : CoroutineMonoExecutor
    {
        public sealed class Factory : PlaceholderFactory<DuckMonoExecutor> { }

        [Inject] private readonly DuckExecutor m_duckExecutor = default;


        protected override BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>> BaseExecutor => m_duckExecutor;
        
    }
}
