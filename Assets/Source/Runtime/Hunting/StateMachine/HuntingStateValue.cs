using LazerLabs.Commands;
using System;

namespace DuckHunt
{
    public interface IHuntingStateValue : IValueContainer<HuntingState> { }

    public interface IHuntingStateObservable : IObservable<HuntingState> { }

    public sealed class HuntingStateValue : CustomObservable<HuntingState>, IHuntingStateValue, IHuntingStateObservable
    {
        private HuntingState m_value = default;


        HuntingState IReadOnlyValueContainer<HuntingState>.Value => m_value;

        HuntingState IValueContainer<HuntingState>.Value
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
