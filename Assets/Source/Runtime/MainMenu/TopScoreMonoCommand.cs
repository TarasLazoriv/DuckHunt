using LazerLabs.Commands;
using TMPro;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public class TopScoreMonoCommand : MonoCommand
    {
        [SerializeField] private TextMeshProUGUI m_maxScoreText = default;

        [Inject] private readonly IPlayerMaxScore m_playerMaxScore = default;

        private const string PlayerMaxScoreText = "TOP SCORE = {0}";

        public override void Execute()
        {
            m_maxScoreText.text = string.Format(PlayerMaxScoreText, m_playerMaxScore.Value);
        }
    }
}
