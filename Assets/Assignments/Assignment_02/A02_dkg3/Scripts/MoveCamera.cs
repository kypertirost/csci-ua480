using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class MoveCamera : MonoBehaviour
    {
        // speed to move the camera
        float speed = 20.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // move to the right on the x-axis
            // also allow the user to move forward and back on the z-axis
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f,
                                      Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
            }
            // move to the left on the x-axis
            // also allow the user to move forward and back on the z-axis
            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f,
                                      Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
            }
            // move up the y-axis
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0.0f, 1.0f, 0.0f);
            }
            // move down the y-axis
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0.0f, -1.0f, 0.0f);
            }
        }
    }
}
