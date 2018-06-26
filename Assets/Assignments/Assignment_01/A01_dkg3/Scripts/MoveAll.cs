using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01dkg3
{
    public class MoveAll : MonoBehaviour
    {
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
            // shift the board and system to the right
            if (count < 90)
            {
                temp.x += .5f;
            }
            // then shift the board and the system to the left
            else
            {
                temp.x -= .5f;
            }
            // reset the count so above if else statements will always be valid
            if (count >= 180)
            {
                count = 0;
            }
            count++;
            transform.position = temp;
        }
    }
}