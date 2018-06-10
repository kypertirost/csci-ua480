using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ml6468.A02 {
    public class Shooting : MonoBehaviour
    {
        public Text enemyText;
        public float damage;
        public Camera mainCam;
        public ParticleSystem muzzleFlash;
        public float durationTime;
        public GameObject hitEffect;

        private int enemyNumber;
        void Start()
        {
            enemyNumber = 11;
            damage = 10.0f;
            durationTime = 3.0f;
            enemyText.text = "Enemy Left: 11/11";
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        public int GetEnemyNumber() {
            return enemyNumber;
        }
        private void Fire()
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, 100.0f))
            {
                Health target = hit.transform.GetComponent<Health>();
                if (target)
                {
                    enemyNumber -= target.MakeDamage(damage);
                }

                GameObject temp = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(temp, durationTime);
                enemyText.text = "Enemy Left: " + enemyNumber + "/11";
            }
        }

    }

}
