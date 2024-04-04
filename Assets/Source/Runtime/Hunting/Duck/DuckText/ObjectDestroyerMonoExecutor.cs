using System;
using System.Collections;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class ObjectDestroyerExecutor : CoroutineTargetExecutor<GameObject>, ICommandVoid<GameObject>
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        protected override ICommand<GameObject, IEnumerator> Command { get; }
        protected override GameObject Target => m_target;

        private GameObject m_target = default;

        public ObjectDestroyerExecutor(ICommandVoid<Func<IEnumerator>> runner, ICommand<GameObject, IEnumerator> command)
        {
            Runner = runner;
            Command = command;
        }

        public void Execute(GameObject target)
        {
            m_target = target;
        }
    }

    public sealed class ObjectDestroyerMonoExecutor : CoroutineMonoExecutor
    {
        public sealed class Factory : PlaceholderFactory<DuckMonoExecutor> { }
        

        private ObjectDestroyerExecutor m_objectDestroyer = default;

        protected override BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>> BaseExecutor => m_objectDestroyer;

        private void Awake()
        {
            IObjectDestroyCommand destroyCommand = new ObjectDestroyCommand();
            MonoCoroutineCommandRunner runner = gameObject.AddComponent<MonoCoroutineCommandRunner>();
            m_objectDestroyer = new ObjectDestroyerExecutor(runner, destroyCommand);
        }

        private void Start()
        {
            m_objectDestroyer.Execute(gameObject);
            Execute();
        }

    }
}
