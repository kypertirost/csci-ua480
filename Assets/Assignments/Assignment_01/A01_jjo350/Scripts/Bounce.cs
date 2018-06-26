using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1_jjo350 {
	public class Bounce : MonoBehaviour
    {

        public float speed = 5f;
        public float dist = 10;
        private bool up = true;

        // Update is called once per frame
        void Update()
        {
            float movement = speed * Time.deltaTime;
            float pos = 0;
            if (up)
            {
                pos = transform.position.y + movement;
                if (pos > dist)
                {
                    float remainder = pos - dist;
                    pos = dist - remainder;
                    up = false;
                }
            }
            else
            {
                pos = transform.position.y - movement;
                float antiDist = 0 - dist;
                if (pos < antiDist)
                {
                    float remainder = pos - antiDist;
                    pos = antiDist - remainder;
                    up = true;
                }
            }
            transform.position = new Vector3(transform.position.x, pos, transform.position.z);
        }
    }

}
