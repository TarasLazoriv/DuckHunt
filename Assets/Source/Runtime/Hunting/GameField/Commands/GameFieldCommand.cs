using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IGetGameFieldCommand : ICommand<GameField> { }

    public sealed class GetGameFieldCommand : IGetGameFieldCommand
    {
        public GameField Execute()
        {
            Camera mainCamera = Camera.main;
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;


            // Find the boundaries of the camera in world coordinates.
            Vector2 bottomLeft = mainCamera.transform.position - new Vector3(cameraWidth / 2, cameraHeight / 2, 0);
            Vector2 topRight = mainCamera.transform.position + new Vector3(cameraWidth / 2, cameraHeight / 2, 0);
            

            return new GameField(bottomLeft, topRight);
        }
    }
}
