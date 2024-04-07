using System;
using System.Collections;
using LazerLabs.Commands;
using UnityEngine.SceneManagement;

namespace DuckHunt
{
    public sealed class StartGameExecutor : BaseExecutor<ICommandVoid<Func<IEnumerator>>, Func<IEnumerator>>, ICommandVoid<IDuckCountValue, Scene>
    {
        protected override ICommandVoid<Func<IEnumerator>> Runner { get; }
        private ICommand<IDuckCountValue, Scene, IEnumerator> Command { get; }
        private IDuckCountValue m_duckCount = default;
        private Scene m_scene = default;

        public StartGameExecutor(ICommandVoid<Func<IEnumerator>> runner, ICommand<IDuckCountValue, Scene, IEnumerator> command)
        {
            Runner = runner;
            Command = command;
        }

        protected override Func<IEnumerator> Context => GenerateContext;


        private IEnumerator GenerateContext()
        {
            return Command.Execute(m_duckCount, m_scene);
        }

        public void Execute(IDuckCountValue v1, Scene v2)
        {
            m_duckCount = v1;
            m_scene = v2;
            Execute();
        }
    }
}