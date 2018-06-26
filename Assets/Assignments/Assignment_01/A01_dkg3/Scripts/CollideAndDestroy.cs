using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01dkg3
{
    public class CollideAndDestroy : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            
        }

        // method to detect collisions of the big ball with smaller balls
        void OnTriggerEnter(Collider col)
		{
            // removes the smaller balls if collided with by the bigger ball
            if(GameObject.Find("Sphere1"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere2"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere3"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere4"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere5"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere6"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere7"))
            {
                Destroy(col.gameObject);
            }

            else if (GameObject.Find("Sphere8"))
            {
                Destroy(col.gameObject);
            }
		}
		
		// Update is called once per frame
		void Update()
        {

        }
    }
}
