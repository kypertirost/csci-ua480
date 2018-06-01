using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ml6468
{
    public class Straight : MonoBehaviour
    {

        public float speed = 1;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }
}