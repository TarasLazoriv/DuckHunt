using System.Collections;
using LazerLabs.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuckHunt
{
    public interface IInitialization : ICommand<Scene, IEnumerator> { }
    public sealed class InitializationCommand: IInitialization
    {
        public IEnumerator Execute(Scene v1)
        {

            AsyncOperation loadCamera = SceneManager.LoadSceneAsync(SceneVariables.Camera, LoadSceneMode.Additive);
            AsyncOperation loadEventSys = SceneManager.LoadSceneAsync(SceneVariables.EventSystem, LoadSceneMode.Additive);
            AsyncOperation loadMainMenu = SceneManager.LoadSceneAsync(SceneVariables.MainMenu, LoadSceneMode.Additive);
            while (!loadCamera.isDone || !loadEventSys.isDone || !loadMainMenu.isDone)
            {
                yield return null;
            }
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneVariables.MainMenu));
            SceneManager.UnloadSceneAsync(v1);
        }
    }
}