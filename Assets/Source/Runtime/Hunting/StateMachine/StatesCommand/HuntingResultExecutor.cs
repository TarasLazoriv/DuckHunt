using System;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public sealed class HuntingResultExecutor : ObserverExecutor<uint>
    {
        protected override ICommandVoid<Action> Runner { get; }
        protected override ICommand Command { get; }

        public HuntingResultExecutor(CommandRunner runner, IHuntingResultCommand command, IActiveDucksCountObservable observable)
        {
            Runner = runner;
            Command = command;
            observable.Subscribe(this);
        }

        public override void OnNext(uint activeDucksCount)
        {
            UnityEngine.Debug.LogError($"{nameof(HuntingResultExecutor)} started");
            if (activeDucksCount == 0)
            {
                base.OnNext(activeDucksCount);
            }
        }
    }
}