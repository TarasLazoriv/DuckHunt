using System.Collections;
using LazerLabs.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DuckHunt
{
    public sealed class StartGameCommand : ICommand<IDuckCountValue, Scene, IEnumerator>
    {
        private readonly ZenjectSceneLoader m_sceneLoader = default;

        public StartGameCommand(ZenjectSceneLoader sceneLoader)
        {
            m_sceneLoader = sceneLoader;
        }

        public IEnumerator Execute(IDuckCountValue duckCountValue, Scene currentScene)
        {
            AsyncOperation operation = m_sceneLoader.LoadSceneAsync(SceneVariables.HuntingScene, LoadSceneMode.Additive, container =>
                 container.Bind<IDuckCountValue>()
                     .FromInstance(duckCountValue)
                     .AsSingle());
            while (!operation.isDone)
            {
                yield return null;
                yield return null;
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneVariables.HuntingScene));
            SceneManager.UnloadSceneAsync(currentScene);

        }
    }
}
