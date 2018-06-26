using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A01_cew385
{
    public class WallColor : MonoBehaviour
    {
        public int amount = 8;
        // Use this for initialization
        void Start()
        {
            for (int j = 0; j < amount; j++)
            {
                this.transform.GetChild(j).GetComponent<MeshRenderer>().material.color = Color.blue;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}