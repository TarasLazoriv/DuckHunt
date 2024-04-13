using System.Collections;
using LazerLabs.Commands;
using TMPro;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public interface IRoundUICommand : ICommand<IEnumerator> { }

    /// <summary>
    /// An example of a mono coroutine command.
    /// </summary>
    public sealed class RoundUIMonoCommand : CoroutineMonoCommand, IRoundUICommand
    {
        [SerializeField] private TextMeshProUGUI m_roundPopUp = default;
        [SerializeField] private TextMeshProUGUI m_roundLabel = default;

        [Inject] private readonly IRoundValue m_round = default;

        private const string RoundPopupString = "ROUND\r\n{0}";
        private const string RoundLabelString = "R={0}";
        public override IEnumerator Execute()
        {
            m_roundPopUp.text = string.Format(RoundPopupString, m_round.Value);
            m_roundLabel.text = string.Format(RoundLabelString, m_round.Value);
            m_roundPopUp.transform.parent.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            m_roundPopUp.transform.parent.gameObject.SetActive(false);
        }
    }
}
