using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public sealed class HuntingStateExecutor : ObserverExecutor<HuntingState>
    {
        protected override ICommand Command => SelectCommand();
        protected override ICommandVoid<Action> Runner { get; }

        private readonly IFirstRoundIntroCommand m_firstRoundIntroCommand = default;
        private readonly INewRoundCommand m_newRoundCommand = default;
        private readonly IHuntingCommand m_huntingCommand = default;
        private readonly IHuntingResultCommand m_huntingResultCommand = default;
        private readonly IRoundResultCommand m_soundResultCommand = default;

        private HuntingState m_currentState = default;

        public HuntingStateExecutor(IFirstRoundIntroCommand firstRoundIntroCommand, INewRoundCommand newRoundCommand, IHuntingCommand huntingCommand, IHuntingResultCommand huntingResultCommand, IRoundResultCommand soundResultCommand, IHuntingStateObservable huntingStateObservable, CommandRunner runner)
        {
            m_firstRoundIntroCommand = firstRoundIntroCommand;
            m_newRoundCommand = newRoundCommand;
            m_huntingCommand = huntingCommand;
            m_huntingResultCommand = huntingResultCommand;
            m_soundResultCommand = soundResultCommand;
            Runner = runner;
            huntingStateObservable.Subscribe(this);
            OnNext(HuntingState.FirstRoundIntro);
        }

        private ICommand SelectCommand()
        {
            return m_currentState switch
            {
                HuntingState.FirstRoundIntro => m_firstRoundIntroCommand,
                HuntingState.NewRound => m_newRoundCommand,
                HuntingState.Hunting => m_huntingCommand,
                HuntingState.HuntingResult => m_huntingResultCommand,
                HuntingState.RoundResult => m_soundResultCommand,
                _ => null
            };
        }

        public override void OnNext(HuntingState state)
        {
            m_currentState = state;
            base.OnNext(state);
        }
    }
}
