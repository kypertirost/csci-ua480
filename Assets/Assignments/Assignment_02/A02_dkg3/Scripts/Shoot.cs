using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class Shoot : MonoBehaviour
    {
        // declare a variables to be used below
        public GameObject projectile;
        public Transform pos;
        public float force = 1000f;
        public float speed = 10f;
        public float accel_decel = 1f;

        // Use this for initialization
        void Start()
        {
            // load the Ball prefab that will be instantiated below
            projectile = Resources.Load("Ball") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {
            // have more force on the shot if the user clicks F (double force)
            if (Input.GetKey(KeyCode.F)) 
            {
                accel_decel = 2f;
            }
            // have less force on the shot if the user clicks H (half force)
            else if (Input.GetKey(KeyCode.H))
            {
                accel_decel = .5f;
            }
            // get back to the default speed by clicking N (normal)
            else if (Input.GetKey(KeyCode.N))
            {
                accel_decel = 1f;
            }

            float horiz = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float vert = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            transform.Translate(new Vector3(horiz, vert, 0f));

            // check for a click to shoot by the user
            if (Input.GetMouseButtonDown(0))
            {
                // instantitate the ball and shoot it from the camera
                GameObject shot = Instantiate(projectile, pos.position, pos.rotation) as GameObject;
                // make it act as a rigidbody
                Rigidbody body = shot.GetComponent<Rigidbody>();
                // shoot it with the given direction, force, and speed
                body.AddForce(pos.forward * force * accel_decel);
            }
        }
    }
}