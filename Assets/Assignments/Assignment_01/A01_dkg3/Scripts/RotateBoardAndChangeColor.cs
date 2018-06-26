using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01dkg3
{
    public class RotateBoardAndChangeColor : MonoBehaviour
    {
        public float speed = 50.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // calculate rotation for each frame
            transform.Rotate(Vector3.down * Time.deltaTime * speed);
            // change the color based on the angle
            if (transform.eulerAngles.y > 0 && transform.eulerAngles.y <= 90) 
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(255/255.0f, 255/255.0f, 255/255.0f);
            }
            else if (transform.eulerAngles.y > 90 && transform.eulerAngles.y <= 180)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(0/255.0f, 0/255.0f, 200/255.0f);
            }
            else if (transform.eulerAngles.y > 180 && transform.eulerAngles.y <= 270)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(0/255.0f, 200/255.0f, 0/ 255.0f);
            }
            else 
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(200/255.0f, 0/255.0f, 0/255.0f);   
            }
        }
    }
}
