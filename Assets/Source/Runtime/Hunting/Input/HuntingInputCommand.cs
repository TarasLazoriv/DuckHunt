using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IHuntingInputCommand : ICommand { }

    public sealed class HuntingInputCommand : IHuntingInputCommand
    {
        private const string DuckTag = "Duck";

        private readonly IShotDuckValue m_shotDuck = default;
        private readonly IShotAmmo m_shotAmmo = default;
        private readonly IHuntingShotSoundCommand m_shotSoundCommand = default;

        public HuntingInputCommand(IShotDuckValue shotDuck, IShotAmmo shotAmmo, IHuntingShotSoundCommand shotSoundCommand)
        {
            m_shotDuck = shotDuck;
            m_shotAmmo = shotAmmo;
            m_shotSoundCommand = shotSoundCommand;
        }

        public void Execute()
        {
            Debug.LogError(m_shotAmmo.Value);
            if (m_shotAmmo.Value > 0)
            {
                Camera mainCamera = Camera.main;
                m_shotAmmo.Value--;
                m_shotSoundCommand.Execute();

                // Starting point of the raycast (camera position)
                Vector3 rayOrigin = mainCamera.ScreenPointToRay(Input.mousePosition).origin;
                // Direction of the raycast (direction from camera to cursor)
                Vector3 rayDirection = mainCamera.ScreenPointToRay(Input.mousePosition).direction;

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);
                Debug.DrawRay(rayOrigin, rayDirection * 20, Color.red, 5f);
                if (hit.collider != null && hit.transform.CompareTag(DuckTag))
                {
                    m_shotDuck.Value = hit.transform.GetInstanceID();
                }
            }
        }

    }
}
