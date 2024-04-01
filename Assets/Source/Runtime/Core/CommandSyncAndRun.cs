using System;
using LazerLabs.Commands;
using Zenject;

public sealed class CommandSyncAndRun : ICommandVoid<Action>, ITickable
{
    private Action m_command = default;

    public CommandSyncAndRun(Action command)
    {
        m_command = command;
    }

    public void Execute(Action command)
    {
        m_command = command;
    }

    public void Tick()
    {
        if (m_command != null)
        {
            m_command.Invoke();
            m_command = null;
        }
    }
}