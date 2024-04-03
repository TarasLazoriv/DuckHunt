using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DogIntroStateMachine : StateMachineBehaviour
    {
        [Inject] private readonly IHuntingStateValue m_huntingStateValue = default;

        [SerializeField] private HuntingState m_newHuntingState = default;

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_huntingStateValue.Value = m_newHuntingState;
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

    }
}
