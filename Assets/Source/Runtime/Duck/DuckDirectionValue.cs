using LazerLabs.Commands;
using System;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckDirectionValue : IValueContainer<DuckDirection> { }

    public interface IDuckDirectionObservable : IObservable<DuckDirection> { }

    public sealed class DuckDirectionValue : CustomObservable<DuckDirection>, IDuckDirectionValue, IDuckDirectionObservable
    {
        private DuckDirection m_value = DuckDirection.Down;
        

        DuckDirection IReadOnlyValueContainer<DuckDirection>.Value => m_value;

        DuckDirection IValueContainer<DuckDirection>.Value
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