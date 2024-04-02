using System;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private TestCommand m_command = default;
        private readonly CommandRunner m_runner = new CommandRunner();
        private TestExecutor m_executor = default;
        [Inject] private DuckMonoExecutor.Factory m_factory = default;

        public class TestCommand : ICommand
        {
            private DuckMonoExecutor.Factory m_prefab = default;

            public TestCommand(DuckMonoExecutor.Factory prefab)
            {
                m_prefab = prefab;
            }
            public void Execute()
            {
                var el = m_prefab.Create();
                el.transform.position = new Vector2(0, -4f);
                el.Execute();
            }
        }

        public class TestExecutor : DefaultExecutor
        {
            public TestExecutor(ICommand command, ICommandVoid<Action> runner) : base(command, runner) { }
        }

        private void Start()
        {
            m_command = new TestCommand(m_factory);
            m_executor = new TestExecutor(m_command, m_runner);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                m_executor.Execute();   
            }
        }
    }
}
