using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_jjo350 {
    public class Explosion : MonoBehaviour
    {
        public float radius = 5.0f;
        public float force = 500.0f;
        public ParticleSystem particles;
		public GameObject instruct;
		private bool inside;

        private bool rendering;
        private void OnBecameVisible() {
            rendering = true;
        }

        private void OnBecameInvisible()
        {
            rendering = false;
        }

        private void Update()
		{
            if (inside && rendering) {
				instruct.SetActive(true);
				if (Input.GetKeyDown(KeyCode.B)) {
					this.Explode();
					instruct.SetActive(false);
				}
			} else {
				instruct.SetActive(false);
			}
        }

        private void OnTriggerEnter(Collider other)
        {
			inside |= (other.tag == "Player");

        }

        private void OnTriggerExit(Collider other)
        {
			inside &= (other.tag != "Player");
        }

        /*
         * I remember most of this procedure from the last time i made an explostion
         * but I did use a tutorial intially and I'm sure my code is pretty similar to his
         * https://www.youtube.com/watch?v=BYL6JtUdEY0
         */
        private void Explode() {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            ParticleSystem particle = Instantiate(particles, transform.position, Quaternion.identity);
            foreach (Collider col in colliders) {
                Rigidbody rb = col.GetComponent<Rigidbody>();

                if (rb != null) {
                    if (rb.tag == "Player")
                    {
                        Debug.Log("hit player");
                    }
                    rb.AddExplosionForce(force, transform.position, radius);

                }
            }
            Destroy(particle, 3.0f);
            Destroy(gameObject);
        }

    }
 
}
