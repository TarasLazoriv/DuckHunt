using System.Collections.Generic;
using System.Linq;
using LazerLabs.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace DuckHunt
{
    public interface IDucksResultCommand : ICommandVoid<IEnumerable<bool>> { }

    /// <summary>
    /// If you don't like using MonoValueContainer or Mono Executors, you can use  Mono commands.
    /// </summary>
    public sealed class DucksResultMonoCommand : MonoCommand<IEnumerable<bool>>, IDucksResultCommand
    {
        [SerializeField] private Image[] m_duckImages = default;

        private static readonly IDictionary<bool, Color> DuckStatusToColor = new Dictionary<bool, Color>()
        {
            {true,Color.red},
            {false,Color.white},
        };

        private static readonly Color UnActiveDuckColor = new Color(1, 1, 1, 0.25f);

        public override void Execute(IEnumerable<bool> target)
        {
            int targetCount = target.Count();
            for (int i = 0; i < m_duckImages.Length; i++)
            {
                if (targetCount > i)
                {
                    bool status = target.ElementAt(i);
                    m_duckImages[i].color = DuckStatusToColor[status];
                }
                else
                {
                    m_duckImages[i].color = UnActiveDuckColor;
                }

            }
        }
    }
}
