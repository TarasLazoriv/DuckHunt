using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IHuntingInputCommand : ICommand { }

    public sealed class HuntingInputCommand : IHuntingInputCommand
    {
        private const string DuckTag = "Duck";

        private readonly IShotDuckValue m_shotDuck = default;

        public HuntingInputCommand(IShotDuckValue shotDuck)
        {
            m_shotDuck = shotDuck;
        }

        //ToDo event and catch by duck obj
        public void Execute()
        {
            Camera mainCamera = Camera.main;

            // Starting point of the raycast (camera position)
            Vector3 rayOrigin = mainCamera.ScreenPointToRay(Input.mousePosition).origin;
            // Direction of the raycast (direction from camera to cursor)
            Vector3 rayDirection = mainCamera.ScreenPointToRay(Input.mousePosition).direction;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);
            Debug.DrawRay(rayOrigin, rayDirection * 20, Color.red, 5f);
            if (hit.collider != null && hit.transform.CompareTag(DuckTag))
            {
                m_shotDuck.Value = hit.transform.GetInstanceID();
                Debug.LogError("finded duck" + hit.collider.gameObject.name);
            }
        }

    }
}
