using LazerLabs.Commands;

namespace DuckHunt
{
    public interface ICaughtDucksValue : IValueContainer<uint> { }
    public sealed class CaughtDucksValue : ICaughtDucksValue
    {
        private uint m_value = default;

        uint IReadOnlyValueContainer<uint>.Value => m_value;

        uint IValueContainer<uint>.Value
        {
            get => m_value;
            set => m_value = value;
        }
    }
}