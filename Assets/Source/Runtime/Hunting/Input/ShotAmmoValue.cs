using LazerLabs.Commands;
using System;

namespace DuckHunt
{
    public interface IShotAmmoObservable : IObservable<uint> { }
    public interface IShotAmmo : IValueContainer<uint> { }
    public sealed class ShotAmmoValue : CustomObservable<uint>, IShotAmmo, IShotAmmoObservable
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