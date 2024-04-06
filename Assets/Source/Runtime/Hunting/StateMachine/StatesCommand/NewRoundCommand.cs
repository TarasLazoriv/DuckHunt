using System;
using LazerLabs.Commands;
using Unity.Mathematics;

namespace DuckHunt
{
    public interface INewRoundCommand : ICommand { }

    public sealed class NewRoundCommand : INewRoundCommand
    {
        private const string AnimationClipName = "DogNewRound";

        private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;
        private readonly IRoundGoalValue m_goal = default;
        private readonly IRoundValue m_round = default;


        public NewRoundCommand(IDogAnimatorContainer dogAnimatorContainer, IRoundGoalValue goalValue, IRoundValue roundValue)
        {
            m_dogAnimatorContainer = dogAnimatorContainer;
            m_goal = goalValue;
            m_round = roundValue;
        }

        public void Execute()
        {
            float coefficient = ((m_round.Value) - 1 * 0.1f + DuckVariables.DefaultGoalValue);
            coefficient = Math.Max(coefficient, DuckVariables.DefaultGoalValue);
            coefficient = Math.Min(coefficient, 1);
            m_goal.Value = (uint)(coefficient * DuckVariables.DucksInTheRound);
            UnityEngine.Debug.LogError($"{nameof(NewRoundCommand)} started");
            m_dogAnimatorContainer.Value.Play(AnimationClipName);
        }
    }
}
