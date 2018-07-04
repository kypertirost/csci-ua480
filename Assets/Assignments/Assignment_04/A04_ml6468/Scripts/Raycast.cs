using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A04{
    public class Raycast : MonoBehaviour
    {
        /*
         *  This is for assignment part 3.
         * 
         *  When an user gaze within 10 meters for 2 seconds, this script is enable,
         *  and the user can teleport to the point. 
         * 
         *  If a player gaze elsewhere, the coroutine will stop and let user can
         *  gradually move if he or she push the button down.
         * 
         */
        public float distance = 10.0f;
        private RaycastHit hitInfo;
        private IEnumerator coroutine;

        void Update()
        {
            coroutine = RaycastGaze();
            StartCoroutine(coroutine);
        }

        private IEnumerator RaycastGaze() {
            while (true) {
                if (Physics.Raycast(transform.position, transform.forward, out hitInfo, distance))
                {
                    yield return new WaitForSeconds(2);
                    Teleport();
                } else {
                    break;
                }
                yield return null;
            }
        }

        private void Teleport() {
            // teleport to the location and stop coroutine after 
            Vector3 teleport = hitInfo.point;
            teleport.y = transform.parent.position.y;
            transform.parent.transform.position = teleport;
            StopCoroutine(coroutine);
        }

    }
}

