using System.Linq;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IRoundResultCommand : ICommand { }

    public sealed class RoundResultCommand : IRoundResultCommand
    {
        private readonly ICaughtDucksValue m_caughtDucksCount = default;
        private readonly IHuntingStateValue m_huntingStateValue = default;
        private readonly IRoundDuckHuntingResult m_duckHuntingResult = default;
        private readonly ILooseRoundCommand m_looseRound = default;
        private readonly IWinRoundCommand m_winRound = default;
        private readonly IRoundResultAnimationExecutor m_roundResultAnimation = default;
        private readonly IRoundGoalValue m_goalValue = default;

        public RoundResultCommand(
            ICaughtDucksValue caughtDucksCount,
            IHuntingStateValue huntingStateValue,
            IRoundDuckHuntingResult duckHuntingResult,
            ILooseRoundCommand looseRound,
            IWinRoundCommand winRound,
            IRoundResultAnimationExecutor roundResultAnimation,
            IRoundGoalValue goalValue)
        {
            m_caughtDucksCount = caughtDucksCount;
            m_huntingStateValue = huntingStateValue;
            m_duckHuntingResult = duckHuntingResult;
            m_looseRound = looseRound;
            m_winRound = winRound;
            m_roundResultAnimation = roundResultAnimation;
            m_goalValue = goalValue;
        }

        public void Execute()
        {
            Debug.LogError($"{nameof(RoundResultCommand)} started");
            m_caughtDucksCount.Value = default;

            if (m_duckHuntingResult.Value.Count() < DuckVariables.DucksInTheRound)
            {
                m_huntingStateValue.Value = HuntingState.Hunting;
            }
            else
            {
                if (m_duckHuntingResult.Value.Count(n => n) > m_goalValue.Value)
                {
                    // win
                    m_roundResultAnimation.Execute(m_winRound);
                }
                else
                {
                    // lose
                    m_roundResultAnimation.Execute(m_looseRound);
                }
            }




        }
    }
}
