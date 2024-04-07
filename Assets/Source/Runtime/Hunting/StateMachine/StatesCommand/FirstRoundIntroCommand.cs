using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IFirstRoundIntroCommand : ICommand { }

    public sealed class FirstRoundIntroCommand : IFirstRoundIntroCommand
    {
        private const string AnimationClipName = "DogIntro";

        private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;

        public FirstRoundIntroCommand(IDogAnimatorContainer dogAnimatorContainer)
        {
            m_dogAnimatorContainer = dogAnimatorContainer;
        }


        public void Execute()
        {
            m_dogAnimatorContainer.Value.Play(AnimationClipName);
        }
    }
}
