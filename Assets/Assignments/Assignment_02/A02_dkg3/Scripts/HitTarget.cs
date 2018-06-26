using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02dkg3
{
    public class HitTarget : MonoBehaviour
    {
        // declare variables to be used below
        public GameObject particles1;
        public GameObject particles2;
        public GameObject hit;
        public static int count = 0;

        // Use this for initialization
        void Start()
        {
            // load the explosion prefabs that will be instantiated below
            particles1 = Resources.Load("Explosion") as GameObject;
            particles2 = Resources.Load("Explosion2") as GameObject;
            // have access to the center of the target
            hit = GameObject.Find("TargetCenter");
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnCollisionEnter(Collision col)
        {
            // removes the target center if collided with by the ball being shot the first time
            if (col.gameObject.name == "Target" && count == 0)
            {
                // remove the center target
                hit.SetActive(false);
                // increment the count
                count++;
            }
            // removes the target if collided with by the ball being shot a second time
            else if (col.gameObject.name == "Target" && count == 1)
            {
                // instantiate the explosions in the position the target was in
                GameObject exp1 = Instantiate(particles1, transform.position, Quaternion.identity) as GameObject;
                GameObject exp2 = Instantiate(particles2, transform.position, Quaternion.identity) as GameObject;
                // remove the target
                col.gameObject.SetActive(false);
                // stop the explosions after 1 iteration to prevent looping
                Destroy(exp1, 1.9f);
                Destroy(exp2, 1.9f);
            }
        }
    }
}
