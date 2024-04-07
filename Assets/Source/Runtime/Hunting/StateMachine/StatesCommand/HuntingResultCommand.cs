using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IHuntingResultCommand : ICommand { }

    public sealed class HuntingResultCommand : IHuntingResultCommand
    {
        private readonly IDogAnimatorContainer m_dogAnimator = default;
        private readonly ICaughtDucksValue m_caughtDucksCount = default;

        private const string AnimationName = "DogRoundResult_";

        public HuntingResultCommand(IDogAnimatorContainer dogAnimator, ICaughtDucksValue caughtDucksCount)
        {
            m_dogAnimator = dogAnimator;
            m_caughtDucksCount = caughtDucksCount;
        }

        public void Execute()
        {
            m_dogAnimator.Value.Play($"{AnimationName}{m_caughtDucksCount.Value}");
        }
    }
}
