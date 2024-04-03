using LazerLabs.Commands;
using Zenject;

namespace DuckHunt
{
    public interface IHuntingCommand : ICommand { }

    public sealed class HuntingCommand : IHuntingCommand
    {
        private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;
        private readonly IDuckSpawnCommand m_factory = default;
        private readonly IDuckCountValue m_duckCountValue = default;

        public HuntingCommand(IDogAnimatorContainer dogAnimatorContainer, IDuckSpawnCommand factory, IDuckCountValue duckCountValue)
        {
            m_dogAnimatorContainer = dogAnimatorContainer;
            m_factory = factory;
            m_duckCountValue = duckCountValue;
        }

        public void Execute()
        {
            m_dogAnimatorContainer.Value.gameObject.SetActive(false);

            for (int i = 0; i < m_duckCountValue.Value; i++)
            {
                m_factory.Execute();
            }
        }
    }
}
