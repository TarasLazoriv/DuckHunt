using Zenject;

namespace DuckHunt
{
    public sealed class PlayerMaxScoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPlayerMaxScore>()
                .To<PlayerMaxScoreContainer>()
                .AsSingle();
        }
    }
}