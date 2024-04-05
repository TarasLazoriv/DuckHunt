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


        public DuckShotDownCommand(
            IDuckTransformContainer duckTransformContainer,
            IDuckDirectionValue directionValue,
            IDuckColliderContainer duckColliderContainer,
            IDuckMoveStoppable moveStoppable,
            IDuckPointsEarnedPrefabContainer duckPointsEarnedPrefab,
            ICanvasValueContainer canvasContainer,
            IDuckAudioSourceContainer audioSourceContainer
            )
        {
            m_duckTransformContainer = duckTransformContainer;
            m_directionValue = directionValue;
            m_duckColliderContainer = duckColliderContainer;
            m_moveStoppable = moveStoppable;
            m_duckPointsEarnedPrefab = duckPointsEarnedPrefab;
            m_canvasContainer = canvasContainer;
            m_audioSourceContainer = audioSourceContainer;
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
            }
        }
    }
}
