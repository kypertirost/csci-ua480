using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class CapsuleCollide : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        void OnCollisionEnter(Collision col)
        {
            // removes the individual capsules if collided with by the ball being shot
            if (col.gameObject.name == "Capsule")
            {
                Destroy(col.gameObject);
            }
            else if (col.gameObject.name == "Capsule2")
            {
                Destroy(col.gameObject);
            }
            else if (col.gameObject.name == "Capsule3")
            {
                Destroy(col.gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
