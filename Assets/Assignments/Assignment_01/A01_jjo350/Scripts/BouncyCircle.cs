using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1_jjo350 {
	public class BouncyCircle : MonoBehaviour
    {

        // Use this for initialization
        public float degreesSeparation = 10.0f;
        public float radius = 10.0f;
        public GameObject sphere;
        void Start()
        {
            for (float i = 0; i <= 360; i += degreesSeparation)
            {
                Quaternion rotation = Quaternion.Euler(0, i, 0);
                Vector3 pos = rotation * new Vector3(0, 0, radius);
                Vector3 startLoc = Vector3.MoveTowards(transform.position, pos, radius);
                GameObject dot = Instantiate(sphere, startLoc, Quaternion.identity, transform);
                dot.SetActive(true);
            }

        }
    }

}
