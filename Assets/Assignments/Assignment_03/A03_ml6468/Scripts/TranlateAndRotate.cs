using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ml6468.A03 {
    public class TranlateAndRotate : MonoBehaviour
    {
        

        Rigidbody rb;
        StrobeSelected strobe;
        bool rotate ; // 0 for translate, 1 for rotate
        bool isBelow;
        bool isGrabbed = false;
        // Use this for initialization
        void Start()
        {
            rotate = false; // set translate mode
            isBelow = false;
            rb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isGrabbed) {
                if (transform.parent.position.y < 1.585f){
                    transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

                }
                if (rotate){
                    transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 20.0f, Input.GetAxis("Mouse X ") * 20.0f, 0));

                }

            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag.Equals("Plane")){
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            }
        }
        public void GrabItem()
        {
            if (isGrabbed)
            {
                transform.parent = null;
                isGrabbed = false;
                rb.isKinematic = false;
                strobe.trigger = false;
            }
            else
            {
                rb.isKinematic = true;
                transform.parent = Camera.main.transform;
                isGrabbed = true;
                strobe.trigger = true;
            }
        }

       
        public void Translate()
        {
            rotate = false;
        }

       
        public void Rotate()
        {
            rotate = true;
        }

        public void Close(Button close){
            for (int i = 0; i < close.transform.parent.childCount; i++)
            {
                close.transform.parent.GetChild(i).gameObject.SetActive(false);
            }
        }
    
    }

}
