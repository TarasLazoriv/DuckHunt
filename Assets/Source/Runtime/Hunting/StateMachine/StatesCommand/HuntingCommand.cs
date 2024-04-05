using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IHuntingCommand : ICommand { }

    public sealed class HuntingCommand : IHuntingCommand
    {
        private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;
        private readonly IDuckSpawnCommand m_factory = default;
        private readonly IDuckCountValue m_duckCountValue = default;
        private readonly IActiveDucksCountValue m_activeDuckCountValue = default;

        public HuntingCommand(IDogAnimatorContainer dogAnimatorContainer, IDuckSpawnCommand factory, IDuckCountValue duckCountValue, IActiveDucksCountValue activeDuckCountValue)
        {
            m_dogAnimatorContainer = dogAnimatorContainer;
            m_factory = factory;
            m_duckCountValue = duckCountValue;
            m_activeDuckCountValue = activeDuckCountValue;
        }

        public void Execute()
        {
            UnityEngine.Debug.LogError($"{nameof(HuntingCommand)} started");
          //  m_dogAnimatorContainer.Value.gameObject.SetActive(false);
            uint duckCount = m_duckCountValue.Value;
            m_activeDuckCountValue.Value = duckCount;
            for (int i = 0; i < duckCount; i++)
            {
                m_factory.Execute();
            }
        }
    }
}
