using LazerLabs.Commands;

namespace DuckHunt
{
    public interface IActiveDucksCountValue : IValueContainer<uint> { }
    public sealed class ActiveDucksCountValue : IActiveDucksCountValue
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
