using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckCommand : ICommand<IEnumerable<Vector2>, IEnumerator> { }

    public sealed class DuckCommand : IDuckCommand
    {
        private const float MinDistance = 0.1f;
        private readonly IDuckTransformContainer m_obj = default;
        private readonly IDuckDirectionCommand m_directionCommand = default;
        private readonly IDuckSpeedValue m_duckSpeed = default;
        private readonly IDuckFlyAwayPrefabContainer m_flyAwayPrefab = default;
        private readonly ICanvasValueContainer m_canvasContainer = default;
        private readonly IDuckDirectionValue m_directionValue = default;
        private readonly IActiveDucksCountValue m_activeDucksCount = default;
        private readonly ICaughtDucksValue m_caughtDucksCount = default;
        private readonly IDuckAudioSourceContainer m_audioSourceContainer = default;
        private readonly IDuckDropAudioContainer m_dropAudioContainer = default;
        private readonly IRoundDuckHuntingAddResult m_addDuckResult = default;
        private readonly IDuckColliderContainer m_duckCollider = default;

        public DuckCommand(
            IDuckTransformContainer obj,
            IDuckDirectionCommand directionCommand,
            IDuckSpeedValue duckSpeed,
            IDuckFlyAwayPrefabContainer flyAwayPrefab,
            ICanvasValueContainer canvasContainer,
            IDuckDirectionValue directionValue,
            IActiveDucksCountValue activeDucksCount,
            ICaughtDucksValue caughtDucksCount,
            IDuckAudioSourceContainer audioSourceContainer,
            IDuckDropAudioContainer dropAudioContainer,
            IRoundDuckHuntingAddResult addDuckResult,
            IDuckColliderContainer duckCollider)
        {
            m_obj = obj;
            m_directionCommand = directionCommand;
            m_duckSpeed = duckSpeed;
            m_flyAwayPrefab = flyAwayPrefab;
            m_canvasContainer = canvasContainer;
            m_directionValue = directionValue;
            m_activeDucksCount = activeDucksCount;
            m_caughtDucksCount = caughtDucksCount;
            m_audioSourceContainer = audioSourceContainer;
            m_dropAudioContainer = dropAudioContainer;
            m_addDuckResult = addDuckResult;
            m_duckCollider = duckCollider;
        }

        public IEnumerator Execute(IEnumerable<Vector2> path)
        {
            for (int i = 0; i < path.Count(); i++)
            {
                Vector3 targetPosition = path.ElementAt(i);
                m_directionCommand.Execute(targetPosition - m_obj.Value.position);
                while (Vector3.Distance(m_obj.Value.position, targetPosition) > MinDistance)
                {
                    m_obj.Value.position = Vector3.MoveTowards(m_obj.Value.position, targetPosition, m_duckSpeed.Value * Time.deltaTime);
                    yield return null;
                }
            }

            m_duckCollider.Value.enabled = false;
            m_audioSourceContainer.Value.Stop();

            if (m_directionValue.Value != DuckDirection.Down)
            {
                Object.Instantiate(m_flyAwayPrefab.Value, m_canvasContainer.Value.transform);
                m_addDuckResult.Execute(false);
            }
            else
            {
                m_caughtDucksCount.Value++;
                m_audioSourceContainer.Value.clip = m_dropAudioContainer.Value;
                m_audioSourceContainer.Value.Play();
                m_addDuckResult.Execute(true);
            }


            m_obj.Value.gameObject.AddComponent<ObjectDestroyerMonoExecutor>();

            yield return new WaitForSeconds(1);

            m_activeDucksCount.Value--;
        }
    }
}
