using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A1_jjo350 {
	public class CircleMaker : MonoBehaviour
	{
		public GameObject block;
		public Transform target;
		public int amount = 10;
		private int counter = 0;

		// Update is called once per frame
        void Update()
        {
			
			if (counter < amount) {
				GameObject build = Instantiate(block);
				build.SetActive(true);
				Halo halo = build.GetComponent<Halo>();
				halo.target = target;
				counter++;
			}

        }
    }
}
