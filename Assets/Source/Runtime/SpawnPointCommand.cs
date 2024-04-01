using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IGetRandomSpawnPointCommand : ICommand<Vector2> { }

    public sealed class SpawnPointCommand : IGetRandomSpawnPointCommand
    {
        public Vector2 Execute()
        {
            Camera mainCamera = Camera.main;
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;


            // Find the boundaries of the camera in world coordinates.
            Vector2 bottomLeft = mainCamera.transform.position - new Vector3(cameraWidth / 2, cameraHeight / 2, 0);
            Vector2 topRight = mainCamera.transform.position + new Vector3(cameraWidth / 2, cameraHeight / 2, 0);

            Debug.Log("Bottom Left: " + bottomLeft);
            Debug.Log("Top Right: " + topRight);

            Vector2 randomPoint = new Vector2(
                Random.Range(bottomLeft.x, topRight.x),
                Random.Range(bottomLeft.y, topRight.y)
            );
            Debug.Log("randomPoint: " + randomPoint);
            return randomPoint;
        }
    }
}
