using System.Collections;
using System.Collections.Generic;
using LazerLabs.Commands;
using TMPro;
using UnityEngine;
using Zenject;

namespace DuckHunt
{

    public interface ITopScoreCommand : ICommand { }
    public class TopScoreMonoCommand : MonoBehaviour, ITopScoreCommand
    {
        [SerializeField] private TextMeshProUGUI m_maxScoreText = default;

        [Inject] private readonly IPlayerMaxScore m_playerMaxScore = default;

        private const string PlayerMaxScoreText = "TOP SCORE = {0}";

        public void Execute()
        {
            m_maxScoreText.text = string.Format(PlayerMaxScoreText, m_playerMaxScore.Value);
        }
    }
}
