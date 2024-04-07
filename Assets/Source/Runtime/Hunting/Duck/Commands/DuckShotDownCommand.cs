using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckShotDownCommand : ICommandVoid<int> { }

    public sealed class DuckShotDownCommand : IDuckShotDownCommand
    {
        private readonly IDuckTransformContainer m_duckTransformContainer = default;
        private readonly IDuckColliderContainer m_duckColliderContainer = default;
        private readonly IDuckDirectionValue m_directionValue = default;
        private readonly IDuckMoveStoppable m_moveStoppable = default;
        private readonly IDuckPointsEarnedPrefabContainer m_duckPointsEarnedPrefab = default;
        private readonly ICanvasValueContainer m_canvasContainer = default;
        private readonly IDuckAudioSourceContainer m_audioSourceContainer = default;
        private readonly IPlayerScore m_playerScore = default;

        public DuckShotDownCommand(
            IDuckTransformContainer duckTransformContainer, 
            IDuckColliderContainer duckColliderContainer, 
            IDuckDirectionValue directionValue,
            IDuckMoveStoppable moveStoppable,
            IDuckPointsEarnedPrefabContainer duckPointsEarnedPrefab,
            ICanvasValueContainer canvasContainer, 
            IDuckAudioSourceContainer audioSourceContainer, 
            IPlayerScore playerScore)
        {
            m_duckTransformContainer = duckTransformContainer;
            m_duckColliderContainer = duckColliderContainer;
            m_directionValue = directionValue;
            m_moveStoppable = moveStoppable;
            m_duckPointsEarnedPrefab = duckPointsEarnedPrefab;
            m_canvasContainer = canvasContainer;
            m_audioSourceContainer = audioSourceContainer;
            m_playerScore = playerScore;
        }

        public void Execute(int duckId)
        {
            if (m_duckTransformContainer.Value.GetInstanceID() == duckId)
            {
                m_audioSourceContainer.Value.Stop();
                m_directionValue.Value = DuckDirection.Down;
                m_duckColliderContainer.Value.enabled = false;
                m_moveStoppable.Stoppable.Execute();
                Vector3 position = Camera.main.WorldToScreenPoint(m_duckTransformContainer.Value.position);
                Object.Instantiate(m_duckPointsEarnedPrefab.Value, position, Quaternion.identity, m_canvasContainer.Value.transform);
                m_playerScore.Value += DuckVariables.ShotDuckPoints;
            }
        }
    }
}
