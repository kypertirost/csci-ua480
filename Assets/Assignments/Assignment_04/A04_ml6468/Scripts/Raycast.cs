using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A04{
    public class Raycast : MonoBehaviour
    {
        /*
         *  
         * 
         * 
         */
        public float distance = 10.0f;
        RaycastHit hitInfo;
        private float time;
        private float moveTime = 3.0f;
        private IEnumerator coroutine;

        private void Start()
        {
            
        }
        void Update()
        {
            coroutine = RaycastGaze();
            StartCoroutine(coroutine);
        }

        private IEnumerator RaycastGaze() {
            while (true) {
                if (Physics.Raycast(transform.position, transform.forward, out hitInfo, distance))
                {
                    Debug.Log("start coroutine");
                    yield return new WaitForSeconds(2);
                    Teleport();
                }
                yield return null;
            }
        }

        private void Teleport() {
            Vector3 teleport = hitInfo.point;
            teleport.y = transform.parent.position.y;
            transform.parent.transform.position = teleport;
            StopCoroutine(coroutine);
        }

    }
}

