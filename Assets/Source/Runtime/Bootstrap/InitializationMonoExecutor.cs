using LazerLabs.Commands;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuckHunt
{
    /// <summary>
    /// Example of using a component-based approach for a coroutine command with input parameter
    /// </summary>
    public sealed class InitializationMonoExecutor : CoroutineCommandMonoExecutor<Scene>
    {
        //Link to mono command
        [SerializeField] private InitializationCommand m_initializationCommand = default;
        //Link to mono runner
        [SerializeField] private CoroutineCommandMonoRunner m_coroutineCommandRunner = default;

        protected override ICommandVoid<Func<IEnumerator>> Runner => m_coroutineCommandRunner;
        protected override ICommand<Scene, IEnumerator> Command => m_initializationCommand;
        protected override Scene Target => gameObject.scene;

    }
}