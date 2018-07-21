﻿using System.Collections;
using UnityEngine;

namespace ml6468.A07{
    public class Bullet : MonoBehaviour
    {

        void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
            }
            Destroy(gameObject);
        }
    }
}

