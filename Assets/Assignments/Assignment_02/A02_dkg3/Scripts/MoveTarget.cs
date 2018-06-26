using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class MoveTarget : MonoBehaviour
    {
        // initialize variables to be used below
        Vector3 temp;
        int count;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            temp = transform.position;
            // reset the count so above if else statements will always be valid
            if (!(count < 300))
            {
                count = 60;
            }
            // shift the target initially from the center to the right
            if (count < 60)
            {
                temp.x += .2f;
            }
            // shift the target to the left end
            else if (count >= 60 && count < 180)
            {
                temp.x -= .2f;
            }
            // shift the target to the right end
            else
            {
                temp.x += .2f;
            }
            // increment the count
            count++;
            transform.position = temp;
        }
    }
}
