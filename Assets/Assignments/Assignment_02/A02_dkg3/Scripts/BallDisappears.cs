using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class BallDisappears : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // destroy any lingering balls after 5 seconds of being shot
            Destroy(gameObject, 5);
        }
    }
}
