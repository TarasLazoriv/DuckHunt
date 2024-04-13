using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IWinRoundCommand : ICommand<IEnumerator> { }

    public sealed class WinRoundCommand : IWinRoundCommand
    {
        private readonly IRoundDuckHuntingReplace m_duckHuntingReplace = default;
        private readonly IRoundDuckHuntingResult m_duckHuntingResult = default;
        private readonly IPerfectValueContainer m_perfectValueContainer = default;
        private readonly IHuntingStateValue m_huntingStateValue = default;
        private readonly IRoundWinSoundCommand m_winSoundCommand = default;
        private readonly IPlayerScore m_playerScore = default;
        private readonly IPlayerMaxScore m_playerMaxScore = default;

        private const int WinRoundAnimationBlinkCount = 7;
        private const float MinAnimationDuration = 3.08f;
        private static readonly IEnumerable<bool> DuckDisabled = new[] { false, false, false, false, false, false, false, false, false, false };

        public WinRoundCommand(
            IRoundDuckHuntingReplace duckHuntingReplace,
            IRoundDuckHuntingResult duckHuntingResult,
            IPerfectValueContainer perfectValueContainer,
            IHuntingStateValue huntingStateValue,
            IRoundWinSoundCommand winSoundCommand,
            IPlayerScore playerScore,
            IPlayerMaxScore playerMaxScore)
        {
            m_duckHuntingReplace = duckHuntingReplace;
            m_duckHuntingResult = duckHuntingResult;
            m_perfectValueContainer = perfectValueContainer;
            m_huntingStateValue = huntingStateValue;
            m_winSoundCommand = winSoundCommand;
            m_playerScore = playerScore;
            m_playerMaxScore = playerMaxScore;
        }

        public IEnumerator Execute()
        {
            List<bool> roundResult = new List<bool>(m_duckHuntingResult.Value);
            m_winSoundCommand.Execute();
            float animationDuration = 0f;
            for (int i = 0; i < WinRoundAnimationBlinkCount; i++)
            {
                if (i != 0)
                {
                    m_duckHuntingReplace.Execute(roundResult);
                    animationDuration += 0.4f;
                    yield return new WaitForSeconds(0.4f);
                }
                m_duckHuntingReplace.Execute(DuckDisabled);
                animationDuration += 0.4f;
                yield return new WaitForSeconds(0.4f);
            }

            if (animationDuration < MinAnimationDuration)
            {
                yield return new WaitForSeconds(MinAnimationDuration - animationDuration);
            }

            bool perfectResult = roundResult.All(b => b);
            if (perfectResult)
            {
                m_playerScore.Value += DuckVariables.PerfectResultPoints;
                m_perfectValueContainer.Value.SetActive(true);
                yield return new WaitForSeconds(2f);
                m_perfectValueContainer.Value.SetActive(false);
            }

            if (m_playerScore.Value > m_playerMaxScore.Value)
            {
                m_playerMaxScore.Value = (int)m_playerScore.Value;
            }
            yield return new WaitForSeconds(0.5f);
            m_huntingStateValue.Value = HuntingState.NewRound;
        }
    }
}
