using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01_cew385
{
    public class Wave : MonoBehaviour
    {
        
        List<Vector3> PreviousPositions;
        List<GameObject> cyl;

        public int amount = 8;
        public int speed = 2;

        void Update()
        {
            for (int i = 0; i < amount; i++)
            {
                this.transform.GetChild(i).transform.position = 
                    new Vector3(this.transform.GetChild(i).transform.position.x, Mathf.Sin(i + Time.time*speed), this.transform.GetChild(i).transform.position.z);
            }
        }
    }
}