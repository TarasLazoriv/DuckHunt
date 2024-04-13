using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public abstract class PlaySoundMonoCommand : MonoCommand, ICommand
    {
        [SerializeField] private AudioSource m_shootSource = default;
        public override void Execute()
        {
            m_shootSource.Play();
        }
    }
}
