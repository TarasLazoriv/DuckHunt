using System.Collections;
using LazerLabs.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuckHunt
{
    /// <summary>
    /// An example of a mono command, but because we have Scene as parameter, it could also just be a command (not a mono command).
    /// </summary>
    public sealed class InitializationCommand : CoroutineMonoCommand<Scene>
    {
        public override IEnumerator Execute(Scene v1)
        {

            AsyncOperation loadCamera = SceneManager.LoadSceneAsync(SceneVariables.Camera, LoadSceneMode.Additive);
            AsyncOperation loadEventSys = SceneManager.LoadSceneAsync(SceneVariables.EventSystem, LoadSceneMode.Additive);
            AsyncOperation loadMainMenu = SceneManager.LoadSceneAsync(SceneVariables.MainMenu, LoadSceneMode.Additive);

            //Waiting for all scenes to load.
            while (!loadCamera.isDone || !loadEventSys.isDone || !loadMainMenu.isDone)
            {
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneVariables.MainMenu));
            SceneManager.UnloadSceneAsync(v1);
        }
    }
}