using System;
using System.Collections.Generic;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IDuckAnimationCommand : ICommandVoid<DuckDirection> { }

    public sealed class DuckAnimationCommand : IDuckAnimationCommand
    {
        private readonly IDuckTransformContainer m_duckTransformContainer = default;
        private readonly IDuckAnimatorContainer m_duckAnimatorContainer = default;

        public DuckAnimationCommand(IDuckTransformContainer duckTransformContainer, IDuckAnimatorContainer duckAnimatorContainer)
        {
            m_duckTransformContainer = duckTransformContainer;
            m_duckAnimatorContainer = duckAnimatorContainer;
        }


        private static readonly IDictionary<DuckDirection, string> DuckAnimationDictionary = new Dictionary<DuckDirection, string>()
        {
            { DuckDirection.Up ,"DirectionTop"},
            { DuckDirection.Down ,"Shutdown"},
            { DuckDirection.Right ,"DirectionRight"},
            { DuckDirection.Left ,"DirectionLeft"},
        };


        public void Execute(DuckDirection direction)
        {
            switch (direction)
            {
                case DuckDirection.Left:
                    m_duckTransformContainer.Value.localScale = new Vector3(-1, 1, 1);
                    break;
                case DuckDirection.Right:
                    m_duckTransformContainer.Value.localScale = Vector3.one;
                    break;
                case DuckDirection.Up:
                    m_duckTransformContainer.Value.localScale = Vector3.one;
                    break;
                case DuckDirection.Down:
                    m_duckTransformContainer.Value.localScale = Vector3.one;
                    break;
            }

            if (DuckAnimationDictionary.TryGetValue(direction, out string animationName))
            {
                m_duckAnimatorContainer.Value.Play(animationName);
            }
        }
    }
}
