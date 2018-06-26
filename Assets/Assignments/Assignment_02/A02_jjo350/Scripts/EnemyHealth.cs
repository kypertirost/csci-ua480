using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_jjo350 {
    public class EnemyHealth : MonoBehaviour
    {

        public int health = 10;

        // Update is called once per frame
        void Update()
        {
            if (health <= 0) {
                Destroy(gameObject);
            }
        }

        // function to decrement health by any generic attack
        public void Damage(int damage) {
            health -= damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "bullet") {
                other.GetComponent<BaseBall>().HitEnemy(gameObject);
            }
        }
    }
 
}
