using System;
using System.Collections;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public sealed class ObjectDestroyerExecutor : CoroutineCommandMonoExecutor<GameObject>
    {
        private ObjectDestroyCommand m_command = default;
        private CoroutineCommandMonoRunner m_runner = default;

        protected override ICommandVoid<Func<IEnumerator>> Runner => m_runner;
        protected override ICommand<GameObject, IEnumerator> Command => m_command;
        protected override GameObject Target => gameObject;


        private void Awake()
        {
            m_command = new ObjectDestroyCommand();
            m_runner = gameObject.AddComponent<CoroutineCommandMonoRunner>();
        }

        protected override void Start()
        {
            base.Start();
            Execute();
        }
    }
}