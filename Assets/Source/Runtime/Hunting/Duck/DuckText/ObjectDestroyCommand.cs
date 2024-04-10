using System.Collections;
using LazerLabs.Commands;
using UnityEngine;

namespace DuckHunt
{

    public sealed class ObjectDestroyCommand : ICommand<GameObject, IEnumerator>
    {
        public IEnumerator Execute(GameObject v1)
        {
            yield return new WaitForSeconds(2f);
            Object.Destroy(v1);
        }
    }
}
