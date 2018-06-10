using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ml6468.A02{
    public class Bullet : MonoBehaviour {
        public float speed = 5.0f;
        void Update() {
            transform.Rotate(new Vector3(1.0f,1.0f,1.0f) * speed);
        }


    }
}

