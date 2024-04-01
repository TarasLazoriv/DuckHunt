using System;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public class NewBehaviourScript : MonoBehaviour
    {
        private TestCommand m_command =default;
        private readonly CommandRunner m_runner = new CommandRunner();
        [Inject] private DuckFactory m_prefab = default;

        public class TestCommand : ICommand
        {
            private DuckFactory m_prefab = default;

            public TestCommand(DuckFactory prefab)
            {
                m_prefab = prefab;
            }
            public void Execute()
            {
                m_prefab.Create();
            }
        }

        public class TestExecutor : DefaultExecutor
        {
            public TestExecutor(ICommand command, ICommandVoid<Action> runner) : base(command, runner) { }
        }

        private void Start()
        {
            m_command = new TestCommand(m_prefab);
            TestExecutor executor = new TestExecutor(m_command, m_runner);
            executor.Execute();
        }
    }
}
