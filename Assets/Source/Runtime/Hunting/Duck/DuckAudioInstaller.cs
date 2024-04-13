using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckAudioInstaller : MonoInstaller
    {
        [SerializeField] private DuckFallingAudioContainer m_duckFallingAudio = default;
        [SerializeField] private DuckDropAudioContainer m_duckDropAudio = default;
        [SerializeField] private DuckAudioSourceContainer m_duckAudioSource = default;

        
        public override void InstallBindings()
        {
            Container
                .Bind<IDuckFallingAudioContainer>()
                .FromInstance(m_duckFallingAudio)
                .AsSingle();

            Container
                .Bind<IDuckDropAudioContainer>()
                .FromInstance(m_duckDropAudio)
                .AsSingle();

            Container
                .Bind<IDuckAudioSourceContainer>()
                .FromInstance(m_duckAudioSource)
                .AsSingle();
            

        }
    }
}
