using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class UserMovesFloorBlock : MonoBehaviour
    {
        // declare variables to be used later
        Vector3 temp;
        Renderer rend;

        // Use this for initialization
        void Start()
        {
            // get access to the renderer componets
            rend = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
            // only perform these actions if the objects are in site of the camera
            if (rend.isVisible)
            {
                temp = transform.position;
                // let the user move the center green block to the left by pressing L (left)
                // don't let it go past the walls
                if (Input.GetKey(KeyCode.L) && temp.x > -16)
                {
                    temp.x -= .1f;
                    print(temp.x);
                }
                // let the user move the center green block to the right by pressing R (right)
                // don't let it go past the walls
                if (Input.GetKey(KeyCode.R) && temp.x < 5.5)
                {
                    temp.x += .1f;
                    print(temp.x);
                }
                transform.position = temp;
            }
        }
    }
}
