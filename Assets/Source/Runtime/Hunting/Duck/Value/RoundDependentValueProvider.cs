using LazerLabs.Commands;

namespace DuckHunt
{
    public abstract class RoundDependentValueProvider : IReadOnlyValueContainer<float>
    {
        protected abstract float DefaultVal { get; }
        protected abstract float DependPower { get; }

        private readonly IRoundValue m_roundValue = default;

        float IReadOnlyValueContainer<float>.Value => Calculate();

        protected RoundDependentValueProvider(IRoundValue roundValue)
        {
            m_roundValue = roundValue;
        }

        protected virtual float Calculate()
        {
            return DefaultVal + (m_roundValue.Value * DependPower);
        }
    }
}