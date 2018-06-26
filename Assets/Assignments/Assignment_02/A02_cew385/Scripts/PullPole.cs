// Christy Welch
// Assignment 2: Forces

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A02_cew385
{
    public class PullPole : MonoBehaviour
    {
        public KeyCode rotate;
        public KeyCode push = KeyCode.Equals;
        public KeyCode pull = KeyCode.Minus;

        public float speed = 70;
        public Transform pole;
        float passed = 0;
        bool canPull = true;
        bool canPush = true;
        Vector3 originalSpot;
        Vector3 oldPosition;
        Rigidbody rb;


        void Start()
        {
            // Initialize Rigidbody for manipulating velocity later
            rb = GetComponent<Rigidbody>();
            originalSpot = pole.transform.position;
        }

        void Update()
        {

            // Get the position of the camera, and only do commands if pole is in viewport
            Vector3 view = Camera.main.WorldToViewportPoint(pole.position);
            if (view.z > 0 && view.x > 0 && view.x < 1 && view.y > 0 && view.y < 1) {

                // Use a key to change the rotation of the foosball pole
                if (Input.GetKey(rotate)){
                    transform.Rotate(0, 0, transform.rotation.z + (speed * Time.deltaTime));
                    passed = Time.time;

                    if(Input.GetKey(pull) && canPull == true){
                        transform.position += new Vector3(0, 0, -0.5f);
                        if(transform.position.z <= -9){
                            canPull = false;
                            canPush = true;
                        }
                        //oldPosition = transform.position;
                    }
                    if (Input.GetKey(push) && canPush == true){
                        transform.position += new Vector3(0, 0, 0.5f);
                        if(transform.position.z >= 9){
                            canPull = true;
                            canPush = false;
                        }
                        //oldPosition = transform.position;
                    }
                }

                // Used to help eliminate the shaking referenced in README
                float newTime = Time.time;
                if (newTime - passed > 3){
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    transform.position = originalSpot;
                }
            }
        }
    }
}