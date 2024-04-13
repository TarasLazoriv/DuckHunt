using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IPlayerMaxScore : IValueContainer<int> { }
    public sealed class PlayerMaxScoreContainer : IPlayerMaxScore
    {

        int IReadOnlyValueContainer<int>.Value => Load();

        int IValueContainer<int>.Value
        {
            get => Load();
            set => PlayerPrefs.SetInt("PlayerMaxScore", value);
        }

        private int Load()
        {
            return PlayerPrefs.GetInt("PlayerMaxScore");
        }
    }
}