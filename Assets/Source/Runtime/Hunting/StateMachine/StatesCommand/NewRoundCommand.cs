using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface INewRoundCommand : ICommand { }

    public sealed class NewRoundCommand : INewRoundCommand
    {
        private const string AnimationClipName = "DogNewRound";

        private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;
        private readonly IRoundDuckHuntingClearResults m_duckHuntingClearResults = default;
        private readonly IRoundGoalValue m_goal = default;
        private readonly IRoundValue m_round = default;
        private readonly IRoundUIExecutor m_roundUI = default;


        public NewRoundCommand(
            IDogAnimatorContainer dogAnimatorContainer,
            IRoundGoalValue goalValue,
            IRoundValue roundValue,
            IRoundDuckHuntingClearResults duckHuntingClearResults,
            IRoundUIExecutor roundUI)
        {
            m_dogAnimatorContainer = dogAnimatorContainer;
            m_goal = goalValue;
            m_round = roundValue;
            m_duckHuntingClearResults = duckHuntingClearResults;
            m_roundUI = roundUI;
        }

        public void Execute()
        {
            m_duckHuntingClearResults.Execute();
            m_round.Value++;
            m_roundUI.Execute();
            float coefficient = ((m_round.Value - 1) * 0.05f + DuckVariables.DefaultGoalValue);
            coefficient = Math.Max(coefficient, DuckVariables.DefaultGoalValue);
            coefficient = Math.Min(coefficient, 1);
            m_goal.Value = (uint)(coefficient * DuckVariables.DucksInTheRound);
            m_dogAnimatorContainer.Value.Play(AnimationClipName);
        }
    }
}
