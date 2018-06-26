using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1_jjo350 {
	public class Revolve : MonoBehaviour
    {

        // Use this for initialization

        public float speed = 30.0f;
		public Vector3 dir;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(dir * speed * Time.deltaTime);
        }
    }
}

