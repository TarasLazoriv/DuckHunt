using LazerLabs.Commands;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuckHunt
{
    public sealed class InitializationMonoExecutor : CoroutineCommandMonoExecutor<Scene>
    {
        [SerializeField] private InitializationCommand m_initializationCommand = default;
        [SerializeField] private CoroutineCommandMonoRunner m_coroutineCommandRunner = default;

        protected override ICommandVoid<Func<IEnumerator>> Runner => m_coroutineCommandRunner;
        protected override ICommand<Scene, IEnumerator> Command => m_initializationCommand;
        protected override Scene Target => gameObject.scene;

    }
}