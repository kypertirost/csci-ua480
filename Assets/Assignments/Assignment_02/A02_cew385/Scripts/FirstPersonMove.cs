using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_cew385
{
    public class FirstPersonMove : MonoBehaviour
    {
        void Update()
        {

            // Move the camera through the scene
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            transform.Translate(moveX, 0, moveZ);
        }
    }
}