using System;
using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IRoundGoalValue : IValueContainer<uint> { }
    public interface IRoundGoalObservable : IObservable<uint> { }
    public sealed class RoundGoalValue : CustomObservable<uint>, IRoundGoalValue, IRoundGoalObservable
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
