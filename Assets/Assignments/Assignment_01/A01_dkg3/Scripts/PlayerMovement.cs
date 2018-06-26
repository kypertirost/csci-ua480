using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01dkg3
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        private float z = 0f;
        private Rigidbody body;

        // Use this for initialization
        void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        // use arrows and R and F buttons to move the orange sphere
        // the goal is to collide with the smaller spheres and destroy them all
        void FixedUpdate()
        {
            // move up
            if (Input.GetKey(KeyCode.R))
            {
                z = 1f;
            }
            // move down
            else if (Input.GetKey(KeyCode.F))
            {
                z = -1f;
            }
            // stay at same height
            else
            {
                z = 0f;
            }
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, z, moveVertical);

            body.AddForce(movement * speed);
        }
    }
}
