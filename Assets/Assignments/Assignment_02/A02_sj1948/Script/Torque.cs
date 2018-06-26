using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assignment02sj1948
{
    public class Torque : MonoBehaviour
    {

        public float speed;
        Rigidbody rb;
        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
            rb.AddTorque(transform.up * speed);
        }
    }
}
