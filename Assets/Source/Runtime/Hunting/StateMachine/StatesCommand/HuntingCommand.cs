using System;
using System.Linq;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IHuntingCommand : ICommand { }

    public sealed class HuntingCommand : IHuntingCommand
    {
        private readonly IDuckSpawnCommand m_factory = default;
        private readonly IDuckCountValue m_duckCountValue = default;
        private readonly IActiveDucksCountValue m_activeDuckCountValue = default;
        private readonly IRoundDuckHuntingResult m_duckHuntingResult = default;
        private readonly IShotAmmo m_shotAmmo = default;


        public HuntingCommand(
            IDuckSpawnCommand factory,
            IDuckCountValue duckCountValue,
            IActiveDucksCountValue activeDuckCountValue,
            IShotAmmo shotAmmo,
            IRoundDuckHuntingResult duckHuntingResult)
        {
            m_factory = factory;
            m_duckCountValue = duckCountValue;
            m_activeDuckCountValue = activeDuckCountValue;
            m_shotAmmo = shotAmmo;
            m_duckHuntingResult = duckHuntingResult;
        }

        public void Execute()
        {
            m_shotAmmo.Value = DuckVariables.DefaultAmmoCount;
            uint duckCount = m_duckCountValue.Value;

            long duckToHunt = DuckVariables.DucksInTheRound - m_duckHuntingResult.Value.Count();
            duckCount = (uint)Math.Min(duckCount, duckToHunt);

            m_activeDuckCountValue.Value = duckCount;
            for (int i = 0; i < duckCount; i++)
            {
                m_factory.Execute();
            }
        }
    }
}
