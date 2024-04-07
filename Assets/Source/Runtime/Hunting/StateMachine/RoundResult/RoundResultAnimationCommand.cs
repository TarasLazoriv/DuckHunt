using System.Collections;
using System.Linq;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IRoundResultAnimationCommand : ICommand<ICommand, IEnumerator> { }

    public sealed class RoundResultAnimationCommand : IRoundResultAnimationCommand
    {
        private readonly IRoundDuckHuntingReplaceToTheEnd m_duckHuntingReplaceToTheEnd = default;
        private readonly IRoundDuckHuntingResult m_duckHuntingResult = default;
        private readonly IPlayScoreSoundCommand m_playScoreSoundCommand = default;
        public RoundResultAnimationCommand(IRoundDuckHuntingReplaceToTheEnd duckHuntingReplaceToTheEnd, IRoundDuckHuntingResult duckHuntingResult, IPlayScoreSoundCommand playScoreSoundCommand)
        {
            m_duckHuntingReplaceToTheEnd = duckHuntingReplaceToTheEnd;
            m_duckHuntingResult = duckHuntingResult;
            m_playScoreSoundCommand = playScoreSoundCommand;
        }

        public IEnumerator Execute(ICommand v1)
        {
            if (!m_duckHuntingResult.Value.All(n => n))
            {
                bool animation = true;
                while (animation)
                {
                    for (int i = 0; i < m_duckHuntingResult.Value.Count(); i++)
                    {
                        bool element = m_duckHuntingResult.Value.ElementAt(i);
                        if (!element)
                        {
                            if (m_duckHuntingResult.Value.Count(n => n) > i)
                            {
                                m_duckHuntingReplaceToTheEnd.Execute(i);
                                m_playScoreSoundCommand.Execute();
                                yield return new WaitForSeconds(0.4f);
                                break;
                            }
                            else
                            {
                                animation = false;
                            }
                        }
                    }
                }
            }

            v1.Execute();
        }
    }
}
