using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A03 {
    public class Translate : MonoBehaviour
    {
        /*
         * This script is used to handle object pure translation wihout rotation.
         * The purpose is if user click on the object, he can move cube back and
         * forth :when user look upward the object will go further, and go closer 
         * to the camera if look downward. When user click the object, it stop.
         * 
         * There is also a system prevent user to go infinitely further.
         * 
         * The current solution is to use mathematical calculation. 
         * 
         */
        public Camera player;

        bool selected;
        bool beyond;
        Vector3 cubeOriginal;
        StrobeSelected strobe;
        //calcuate distance param
        float camPre;

        void Start()
        {
            selected = false;
            beyond = false;
            cubeOriginal = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            camPre = player.transform.rotation.x;
            strobe = transform.GetComponent<StrobeSelected>();
            strobe.strobeColor = Color.grey;
        }

        // Update is called once per frame
        void Update()
        {
            beyond = CheckBeyond(-18.0f);
            if (selected)
            {
                // The "0.5f" below is require because otherwise the cube will move with the user's head but cannot stop at 
                // further postition.
                float dis = -(player.transform.rotation.x - camPre * 0.5f) * 2; //calculate distance

                camPre = player.transform.rotation.x; 
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + dis);// assign
                if (beyond)
                {
                    transform.position = cubeOriginal;
                    selected = false;
                }
            }
            if (transform.position.y < 0) {
                // if the cube accidentally falls below the ground
                transform.position = cubeOriginal;
            }

        }

        public void ChangeSelectedMode()
        {
            if (selected)
            {
                //handle not selected 
                selected = false;
                strobe.trigger = false;

            }
            else
            {
                //handle selcted
                selected = true;
                strobe.trigger = true;
            }
        }

        /*
         * Check whether the user "too upward"
         */
        private bool CheckBeyond(float limit)
        {
            if (player.transform.rotation.x < limit)
            {
                return true;
            }
            else return false;
        }
    }

}
