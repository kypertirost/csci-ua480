using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment03sj1948Par1
{
    /***
     * Rotation component allows user to select this object and 
     * rotate it with their gaze
     ******/
    public class Rotation : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        float Magnitude;
        Vector3 Angle;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame

        void Update()
        {
            if (grabbed)
            {
                //if selected the object will rotate left or right depending where the camera turns
                // make it move with gaze, keeping same distance from camera
                float difference = Angle.y - Camera.main.transform.rotation.eulerAngles.y;
                transform.Rotate(Vector3.up, difference * 8);
                Angle = Camera.main.transform.rotation.eulerAngles;

            }
        }


        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                // release the object
                grabbed = false;
                myRb.useGravity = true;
            }
            else
            {   // pick it up
                Magnitude = Vector3.Project(transform.position - Camera.main.transform.position, Camera.main.transform.right).magnitude;
                Angle = Camera.main.transform.rotation.eulerAngles;
                grabbed = true;
                myRb.useGravity = false;

            }
        }
    }
}
