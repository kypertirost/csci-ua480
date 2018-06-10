using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ml6468.A02{
    public class Health : MonoBehaviour
    {
        public float health;

        public int MakeDamage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(this.gameObject);
                return 1;
            }
            else return 0;

        }

    }
}

