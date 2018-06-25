using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A03
{
    [RequireComponent(typeof(Rigidbody))]
    public class Pickup : MonoBehaviour
    {
        /*
         * The code are based on the class example PickupMe.cs
         * 
         * This script is used to let user grab the item when
         * selected and move to any position with a "shadow" 
         * below to identify the position when user "put" the item
         * down. If useer move the object below the plane, the
         * item will go above to the plane.
         * 
         * isGrabbed: use to identify user grab or not
         * isBelow  : use to identify item is below the ground
         * 
         */
        public Transform shadow;
        bool isGrabbed;
        bool isBelow;
        Rigidbody rb;
        StrobeSelected strobe;
        void Start()
        {
            isGrabbed = false;
            isBelow = false;
            rb = transform.GetComponent<Rigidbody>();
            strobe = transform.GetComponent<StrobeSelected>();
            strobe.strobeColor = Color.grey;
        }

        // Update is called once per frame
        void Update()
        {
            if (isGrabbed){
                CreateFakeShadow();
                if (transform.parent.position.y < 1.585f)
                {
                    transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                }
            }

        }

        public void GrabItem()
        {
            if (isGrabbed) {
                transform.parent = null;
                isGrabbed = false;
                rb.isKinematic = false;
                strobe.trigger = false;
            } else {
                rb.isKinematic = true;
                transform.parent = Camera.main.transform;
                isGrabbed = true;
                strobe.trigger = true;
            }
        }

        /*
         * Create a fake shadow to let user identify where the object
         * will be if he or she drops the cube
         */
        private void CreateFakeShadow() {
            shadow.position = new Vector3(transform.position.x, shadow.position.y, transform.position.z);
        }
    }
}