using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IShotDuckValue : IValueContainer<int> { }
    public interface IShotDuckObservable : IObservable<int> { }

    public sealed class ShotDuckValue : CustomObservable<int>, IShotDuckValue, IShotDuckObservable
    {
        private int m_value = default;

        int IReadOnlyValueContainer<int>.Value => m_value;

        int IValueContainer<int>.Value
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
