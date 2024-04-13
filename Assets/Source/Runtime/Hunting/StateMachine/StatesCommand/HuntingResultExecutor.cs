using System;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public sealed class HuntingResultExecutor : CommandObserverExecutor<uint>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommand Command { get; }

        public HuntingResultExecutor(ICommandRunner runner, IHuntingResultCommand command, IActiveDucksCountObservable observable)
        {
            Runner = runner;
            Command = command;
            observable.Subscribe(this);
        }

        public override void OnNext(uint activeDucksCount)
        {
            if (activeDucksCount == 0)
            {
                base.OnNext(activeDucksCount);
            }
        }
    }
}