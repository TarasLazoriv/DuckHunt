using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckCommand : ICommand<IEnumerator> { }

    public sealed class DuckCommand : IDuckCommand
    {
        private const float MinDistance = 0.1f;
        private readonly IDuckTransformContainer m_obj = default;
        private readonly IPathGeneratorCommand m_pathGeneratorCommand = default;
        private readonly IDuckDirectionCommand m_directionCommand = default;
        private readonly IDuckSpeedValue m_duckSpeed = default;

        public DuckCommand(IDuckTransformContainer obj, IPathGeneratorCommand pathGeneratorCommand, IDuckDirectionCommand directionCommand, IDuckSpeedValue duckSpeed)
        {
            m_obj = obj;
            m_pathGeneratorCommand = pathGeneratorCommand;
            m_directionCommand = directionCommand;
            m_duckSpeed = duckSpeed;
        }

        public IEnumerator Execute()
        {
            IEnumerable<Vector2> path = m_pathGeneratorCommand.Execute(m_obj.Value.position);
            for (int i = 1; i < path.Count(); i++)
            {
                Vector3 targetPosition = path.ElementAt(i);
                m_directionCommand.Execute(targetPosition - m_obj.Value.position);
                while (Vector3.Distance(m_obj.Value.position, targetPosition) > MinDistance)
                {
                    m_obj.Value.position = Vector3.MoveTowards(m_obj.Value.position, targetPosition, m_duckSpeed.Value * Time.deltaTime);
                    yield return null;
                }
            }
        }
    }
}
