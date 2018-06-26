using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_jjo350 {
    public class BaseBall : MonoBehaviour
    {
        public ParticleSystem particles;

        public void HitEnemy(GameObject enemy) {
            enemy.GetComponent<EnemyHealth>().Damage(1);
            ParticleSystem bam = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(bam, 2f);
            Destroy(gameObject);
        }
    }
}

