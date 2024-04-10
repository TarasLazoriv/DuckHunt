using System;
using System.Collections.Generic;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class DucksResultExecutor : CommandObserverTargetExecutor<IEnumerable<bool>>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommandVoid<IEnumerable<bool>> Command { get; }

        public DucksResultExecutor(CommandRunner runner, IDucksResultCommand command, IRoundDuckHuntingResultObservable huntingResultObservable)
        {
            Runner = runner;
            Command = command;
            huntingResultObservable.Subscribe(this);
        }
    }
}