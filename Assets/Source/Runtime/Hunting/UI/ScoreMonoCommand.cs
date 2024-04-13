using LazerLabs.Commands;
using TMPro;
using UnityEngine;

namespace DuckHunt
{
    public interface IScoreCommand : ICommandVoid<uint> { }
    public sealed class ScoreMonoCommand : MonoCommand<uint>, IScoreCommand
    {
        [SerializeField] private TextMeshProUGUI m_scoreText = default;
        public override void Execute(uint v1)
        {
            m_scoreText.text = v1.ToString("D6");
        }
    }
}
