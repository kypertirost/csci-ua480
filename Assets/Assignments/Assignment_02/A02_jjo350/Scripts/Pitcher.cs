using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_jjo350 {
    public class Pitcher : MonoBehaviour
    {
        public GameObject baseball;
        private bool firing = false;
        public float strength = 200.0f;
        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetButtonDown("Fire1")) {
                GameObject ball = Instantiate(baseball, Camera.main.transform.position, Quaternion.identity);
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                Quaternion rotation = transform.rotation;
                Vector3 dir = rotation * Vector3.forward;
                rb.AddForce(dir * strength);
            }
        }
    }

}
