using LazerLabs.Commands;

namespace DuckHunt
{
    public interface INewRoundCommand : ICommand { }

    public sealed class NewRoundCommand : INewRoundCommand
    {
        private const string AnimationClipName = "DogNewRound";

        private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;

        public NewRoundCommand(IDogAnimatorContainer dogAnimatorContainer)
        {
            m_dogAnimatorContainer = dogAnimatorContainer;
        }

        public void Execute()
        {
            UnityEngine.Debug.LogError($"{nameof(NewRoundCommand)} started");
            m_dogAnimatorContainer.Value.Play(AnimationClipName);
        }
    }
}
