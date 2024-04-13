using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IPlayerScore : IValueContainer<uint> { }
    public interface IObservablePlayerScore : IObservable<uint> { }

    public sealed class PlayerScoreContainer : CustomObservable<uint>, IPlayerScore, IObservablePlayerScore
    {
        private uint m_value;

        uint IReadOnlyValueContainer<uint>.Value => m_value;

        uint IValueContainer<uint>.Value
        {
            get => m_value;
            set
            {
                if (m_value != value)
                {
                    m_value = value;
                    NotifyObservers(m_value);
                }
            }
        }
    }
}
