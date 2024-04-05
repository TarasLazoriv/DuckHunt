using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class HuntingStateChangeMonoCommand : MonoBehaviour, ICommandVoid<HuntingState>
    {
        [Inject] private readonly IHuntingStateValue m_huntingStateValue = default;
        public void Execute(HuntingState v1)
        {
            m_huntingStateValue.Value = v1;
        }
    }
}