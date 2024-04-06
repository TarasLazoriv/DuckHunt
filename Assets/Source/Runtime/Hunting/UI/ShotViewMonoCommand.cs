using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IShotViewCommand : ICommandVoid<uint> { }

    public sealed class ShotViewMonoCommand : MonoBehaviour, IShotViewCommand
    {
        [SerializeField] private GameObject[] m_ammoObjects = default;
        public void Execute(uint ammo)
        {
            for (int i = 0; i < m_ammoObjects.Length; i++)
            {
                m_ammoObjects[i].SetActive(ammo > i);
            }
        }
    }
}
