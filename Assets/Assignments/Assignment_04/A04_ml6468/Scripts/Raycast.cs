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
        private float moveTime = 2.0f;
        private IEnumerator coroutine;

        private void Start()
        {
            
        }
        void Update()
        {
            

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, distance))
            {
                Debug.Log("start coroutine");
                coroutine = RaycastGaze();
                StartCoroutine(coroutine);
            } 

        }

        private IEnumerator RaycastGaze() {
            time = 0.0f;
            Debug.Log("hit");
            while (time < moveTime) {
                time += Time.deltaTime;
                yield return null;
            }
            Teleport();
        }

        private void Teleport() {
            Vector3 teleport = hitInfo.point;
            teleport.y = transform.parent.position.y;
            transform.parent.transform.position = teleport;
            time = 0;
            StopCoroutine(coroutine);
        }

    }
}

