using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public sealed class DuckFallStateMachine : StateMachineBehaviour
    {
        [Inject] private readonly IDuckFallCommand m_duckFallCommand = default;

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_duckFallCommand.Execute();
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

    }
}