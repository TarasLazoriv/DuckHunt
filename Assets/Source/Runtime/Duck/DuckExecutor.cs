using System;
using System.Collections;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DuckExecutor : CoroutineExecutor
    {
        public DuckExecutor(IDuckCommand command, CoroutineCommandRunner runner) : base(command, runner)
        {
        }
    }
}