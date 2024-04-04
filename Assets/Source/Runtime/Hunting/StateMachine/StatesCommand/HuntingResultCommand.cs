using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IHuntingResultCommand : ICommand { }

    public sealed class HuntingResultCommand : IHuntingResultCommand
    {
        public void Execute()
        {
            Debug.LogError($"Result  ducks!");
        }
    }
}
