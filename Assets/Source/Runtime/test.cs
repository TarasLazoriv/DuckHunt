using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuckHunt
{
    public class test : MonoBehaviour
    {
        [SerializeField] private GameObject go;
        // Start is called before the first frame update
        void Start()
        {
            IGetGameFieldCommand gameField = new GetGameFieldCommand();
            PathGeneratorCommand p = new PathGeneratorCommand(gameField);

            var r = p.Execute(transform.position);

            foreach (var v in r)
            {
                Debug.LogError(v);
                var el = GameObject.Instantiate(go);
                el.transform.localScale = Vector3.one;
                el.transform.position = v;
            }

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
