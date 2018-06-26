using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1_jjo350 {
	public class Halo : MonoBehaviour
    {

		public Transform target;
		public float speed = 1f;
		private Vector3 targetPos;
		private float startTime;
        private float journeyLength;
		// Use this for initialization

        void Start()
        {
			targetPos = target.position;
			startTime = Time.time;
			journeyLength = Vector3.Distance(targetPos, transform.position);
        }

        // Update is called once per frame
        void Update()
        {
			float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
           
			transform.position = Vector3.Lerp(transform.position, targetPos, fracJourney);
        }
    }
}

