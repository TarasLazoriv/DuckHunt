using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckMonoExecutor : MonoBehaviour, ICommandVoid<IEnumerable<Vector2>>
    {
        public sealed class Factory : PlaceholderFactory<DuckMonoExecutor> { }

        [Inject] private readonly DuckExecutor m_duckExecutor = default;

        public void Execute(IEnumerable<Vector2> v1)
        {
            m_duckExecutor.Execute(v1);
        }
    }
}
