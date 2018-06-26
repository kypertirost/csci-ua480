using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_jjo350 {
    public class Suicider : MonoBehaviour
    {

        public float timeToLive = 5.0f;

        // Update is called once per frame
        void Update()
        {
            timeToLive -= Time.deltaTime;
            if (timeToLive <= 0)
            {
                Destroy(gameObject);
            }
        }
    } 
}

