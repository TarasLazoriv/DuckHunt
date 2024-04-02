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
        private const float Speed = 5f;
        private readonly ITransformContainer m_obj = default;
        private readonly IPathGeneratorCommand m_pathGeneratorCommand = default;

        public DuckCommand(ITransformContainer obj, IPathGeneratorCommand pathGeneratorCommand)
        {
            m_obj = obj;
            m_pathGeneratorCommand = pathGeneratorCommand;
        }

        public IEnumerator Execute()
        {
            IEnumerable<Vector2> path = m_pathGeneratorCommand.Execute(m_obj.Value.position);
            for (int i = 0; i < path.Count(); i++)
            {
                Vector3 targetPosition = path.ElementAt(i);
                while (Vector3.Distance(m_obj.Value.position, targetPosition) > MinDistance)
                {
                    m_obj.Value.position = Vector3.MoveTowards(m_obj.Value.position, targetPosition, Speed * Time.deltaTime);
                    yield return null;
                }
            }
        }
    }
}
