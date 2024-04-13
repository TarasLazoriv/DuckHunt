using LazerLabs.Commands;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DuckHunt
{
    public interface ILooseRoundCommand : ICommand<IEnumerator> { }

    public sealed class GameOverMonoCommand : CoroutineMonoCommand, ILooseRoundCommand
    {
        [SerializeField] private AudioSource m_gameOverAudioSource = default;
        [SerializeField] private GameObject m_gameOverUIObject = default;

        [Inject] private readonly IDogAnimatorContainer m_dogAnimatorContainer = default;
        [Inject] private readonly IPlayerScore m_playerScore = default;
        [Inject] private readonly IPlayerMaxScore m_playerMaxScore = default;

        private const string AnimationClipName = "DogGameOver";


        public override IEnumerator Execute()
        {
            m_gameOverAudioSource.Play();
            m_gameOverUIObject.SetActive(true);
            while (m_gameOverAudioSource.isPlaying)
            {
                yield return null;
            }
            m_dogAnimatorContainer.Value.Play(AnimationClipName);

            if (m_playerScore.Value > m_playerMaxScore.Value)
            {
                m_playerMaxScore.Value = (int)m_playerScore.Value;
            }

            yield return new WaitForSeconds(5);

            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneVariables.MainMenu, LoadSceneMode.Additive);

            while (!operation.isDone)
            {
                yield return null;
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneVariables.MainMenu));
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}
