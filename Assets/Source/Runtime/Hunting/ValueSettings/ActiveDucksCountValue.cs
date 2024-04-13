using LazerLabs.Commands;
using System;

namespace DuckHunt
{
    public interface IActiveDucksCountObservable : IObservable<uint> { }
    public interface IActiveDucksCountValue : IValueContainer<uint> { }
    public sealed class ActiveDucksCountValue : CustomObservable<uint>, IActiveDucksCountValue, IActiveDucksCountObservable
    {
        private uint m_value = default;

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
