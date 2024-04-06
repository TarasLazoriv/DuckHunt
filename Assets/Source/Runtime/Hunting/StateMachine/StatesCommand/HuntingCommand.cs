using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IHuntingCommand : ICommand { }

    public sealed class HuntingCommand : IHuntingCommand
    {
        private readonly IDuckSpawnCommand m_factory = default;
        private readonly IDuckCountValue m_duckCountValue = default;
        private readonly IActiveDucksCountValue m_activeDuckCountValue = default;
        private readonly IShotAmmo m_shotAmmo = default;

        private const uint DefaultAmmoCount = 3;

        public HuntingCommand(IDuckSpawnCommand factory, IDuckCountValue duckCountValue, IActiveDucksCountValue activeDuckCountValue, IShotAmmo shotAmmo)
        {
            m_factory = factory;
            m_duckCountValue = duckCountValue;
            m_activeDuckCountValue = activeDuckCountValue;
            m_shotAmmo = shotAmmo;
        }

        public void Execute()
        {
            UnityEngine.Debug.LogError($"{nameof(HuntingCommand)} started");
            m_shotAmmo.Value = DefaultAmmoCount;
            uint duckCount = m_duckCountValue.Value;
            m_activeDuckCountValue.Value = duckCount;
            for (int i = 0; i < duckCount; i++)
            {
                m_factory.Execute();
            }
        }
    }
}
