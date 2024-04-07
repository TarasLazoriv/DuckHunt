using System;
using System.Collections;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public sealed class TopScoreMonoExecutor : DefaultMonoExecutor
    {
        [SerializeField] private TopScoreMonoCommand m_command = default;
        protected override BaseExecutor<ICommandVoid<Action>, Action> BaseExecutor => m_executor;

        private TopScoreExecutor m_executor = default;

        private void Awake()
        {
            m_executor = new TopScoreExecutor(new CommandRunner(), m_command);
        }


        private void Start()
        {
            Execute();
        }


    }
}
