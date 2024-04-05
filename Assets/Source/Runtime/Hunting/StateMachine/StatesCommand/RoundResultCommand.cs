using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public interface IRoundResultCommand : ICommand {}

    public sealed class RoundResultCommand : IRoundResultCommand
    {
        private readonly ICaughtDucksValue m_caughtDucksCount = default;
        private readonly IHuntingStateValue m_huntingStateValue = default;

        public RoundResultCommand(ICaughtDucksValue caughtDucksCount, IHuntingStateValue huntingStateValue)
        {
            m_caughtDucksCount = caughtDucksCount;
            m_huntingStateValue = huntingStateValue;
        }
        

        public void Execute()
        {
            Debug.LogError($"{nameof(RoundResultCommand)} started");
            m_caughtDucksCount.Value = default;
            m_huntingStateValue.Value = HuntingState.Hunting;
        }
    }
}
