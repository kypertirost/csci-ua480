// Christy Welch
// Assignment 2: Forces

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A02_cew385
{
    public class ScoreGoal : MonoBehaviour
    {
        Vector3 campos;
        GameObject ball;
        bool ready = false;
        bool shotone = false;

        public KeyCode newBall = KeyCode.Space; // Allow user to pick key for ball instantiation
        public Rigidbody nextball; // Allow user to set the desired ball object

        void Start()
        {
            // Save the starting position of the camera
            campos = Camera.main.transform.position;
        }

        // When ball crosses into goal box, reset the camera
        // and notify that we are ready for a new ball instantiation
        private void OnTriggerEnter(Collider other)
        {
            Camera.main.GetComponent<Transform>().position = campos;
            Debug.Log("GOAL!");
            ball = GameObject.FindWithTag("Ball");
            ready = true;
        }

        void Update()
        {
            // If the hotkey is pressed, the goal has been triggered, and you haven't shot yet..
            if(Input.GetKey(newBall) && ready == true && shotone == false){

                // Instantiate and shoot new ball into table
                Rigidbody clone;
                clone = Instantiate(nextball, Camera.main.transform.position, Camera.main.transform.rotation) as Rigidbody;
                clone.AddRelativeForce(30, 20, 500);
       
                // Can only be shot once per goal
                shotone = true;

                // Destroy the old ball
                Destroy(ball, 5);

            }
        }
    }
}