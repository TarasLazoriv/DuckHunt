using System;
using LazerLabs.Commands;
using UnityEngine;
using Zenject;

namespace DuckHunt
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [Inject] private IDuckSpawnCommand m_factory = default;
        

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                m_factory.Execute();   
            }
        }
    }
}
