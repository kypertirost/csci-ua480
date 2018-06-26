using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01dkg3
{
    public class RotateAndScale : MonoBehaviour
    {
        public float speed = 10.0f;
        Vector3 temp;
        int count;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            temp = transform.localScale;
            // calculate rotation for each frame
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
            // increase size of outer spheres for first 50 frames
            if (count < 50) 
            {
                temp.x += .01f;
                temp.y += .01f;
                temp.z += .01f;
            }
            // decrease size of out spheres for next 50 frames
            else 
            {
                temp.x -= .01f;
                temp.y -= .01f;
                temp.z -= .01f;
            }
            // reset the count so above if else statements will always be valid
            if (count >= 100) 
            {
                count = 0;
            }
            count++;
            transform.localScale = temp;
        }
    }
}
