using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01
{
    public class Move : MonoBehaviour
    {

        public float speed = 1;
        public float amount = 1;
        public float offset = 0;
        public float x;
        public float z;

        void Start()
        {

        }

        void Update()
        {
            transform.localPosition = new Vector3(x, Mathf.Sin(offset + Time.time * speed) * amount, z);
        }
    }
}