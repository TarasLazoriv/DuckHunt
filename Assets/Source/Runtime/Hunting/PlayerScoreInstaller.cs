using Zenject;

namespace DuckHunt
{
    public sealed class PlayerScoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(IPlayerScore), typeof(IObservablePlayerScore))
                .To<PlayerScoreContainer>()
                .AsSingle();
        }
    }
}
