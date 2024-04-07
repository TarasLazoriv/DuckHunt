using LazerLabs.Commands;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace DuckHunt
{
    public sealed class InitializationMonoExecutor : CoroutineMonoExecutor
    {


        private InitializationExecutor m_init = default;

        protected override BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>> BaseExecutor => m_init;

        private void Awake()
        {
            IInitialization initCommand = new InitializationCommand();
            MonoCoroutineCommandRunner runner = gameObject.AddComponent<MonoCoroutineCommandRunner>();
            m_init = new InitializationExecutor(runner, initCommand);
        }

        private void Start()
        {
            m_init.Execute(gameObject.scene);
            Execute();
        }
    }
    public sealed class InitializationExecutor : CoroutineTargetExecutor<Scene>, ICommandVoid<Scene>
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<Scene, IEnumerator> Command { get; }
        protected override Scene Target => m_target;

        private Scene m_target = default;

        public InitializationExecutor(ICommandVoid<Func<IEnumerator>> runner, ICommand<Scene, IEnumerator> command)
        {
            Runner = runner;
            Command = command;
        }

        public void Execute(Scene target)
        {
            m_target = target;
        }
    }


}
