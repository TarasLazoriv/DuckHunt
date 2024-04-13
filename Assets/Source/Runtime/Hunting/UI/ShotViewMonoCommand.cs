using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IShotViewCommand : ICommandVoid<uint> { }

    /// <summary>
    /// If you don't like using MonoValueContainer or Mono Executors, you can use  Mono commands.
    /// </summary>
    public sealed class ShotViewMonoCommand : MonoCommand<uint>, IShotViewCommand
    {
        [SerializeField] private GameObject[] m_ammoObjects = default;
        public override void Execute(uint ammo)
        {
            for (int i = 0; i < m_ammoObjects.Length; i++)
            {
                m_ammoObjects[i].SetActive(ammo > i);
            }
        }
    }
}
