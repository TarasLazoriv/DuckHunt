using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public abstract class PlaySoundMonoCommand : MonoBehaviour, ICommand
    {
        [SerializeField] private AudioSource m_shootSource = default;
        public void Execute()
        {
            m_shootSource.Play();
        }
    }
}
