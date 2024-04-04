using System.Collections;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{
    public interface IObjectDestroyCommand : ICommand<GameObject, IEnumerator> { }

    public sealed class ObjectDestroyCommand : IObjectDestroyCommand
    {
        public IEnumerator Execute(GameObject v1)
        {
            yield return new WaitForSeconds(2f);
            Object.Destroy(v1);
        }
    }
}
