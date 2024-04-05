using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IHuntingResultCommand : ICommand { }

    public sealed class HuntingResultCommand : IHuntingResultCommand
    {
        private readonly IDogAnimatorContainer m_dogAnimator = default;
        private readonly ICaughtDucksValue m_caughtDucksCount = default;
        private readonly IHuntingStateValue m_huntingStateValue = default;

        private const string AnimationName = "DogRoundResult_";

        public HuntingResultCommand(IDogAnimatorContainer dogAnimator, ICaughtDucksValue caughtDucksCount, IHuntingStateValue huntingStateValue)
        {
            m_dogAnimator = dogAnimator;
            m_caughtDucksCount = caughtDucksCount;
            m_huntingStateValue = huntingStateValue;
        }

        public void Execute()
        {
            UnityEngine.Debug.LogError($"{nameof(HuntingResultCommand)} started with val {m_huntingStateValue.Value}");
         //   m_dogAnimator.Value.gameObject.SetActive(true);
            m_dogAnimator.Value.Play($"{AnimationName}{m_caughtDucksCount.Value}");
        }
    }
}
