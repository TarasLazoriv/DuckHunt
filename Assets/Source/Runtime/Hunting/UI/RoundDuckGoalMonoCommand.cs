using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IRoundDuckGoalCommand : ICommandVoid<uint> { }

    public sealed class RoundDuckGoalMonoCommand : MonoBehaviour, IRoundDuckGoalCommand
    {
        [SerializeField] private GameObject[] m_duckGoalImages = default;


        public void Execute(uint goal)
        {

            float coefficient = goal / ((float)DuckVariables.DucksInTheRound);
            int index = (int)(m_duckGoalImages.Length * coefficient);
            for (int i = 0; i < m_duckGoalImages.Length; i++)
            {
                m_duckGoalImages[i].SetActive(i < index);
            }
        }
    }
}
