using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01_cew385
{
    public class ShootCanon : MonoBehaviour
    {
        //public Vector3 start = new Vector3();
        //public Vector3 end = ;
        public float speed = 5;
        //GameObject parent;
        void Start()
        {
            this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.cyan;
            this.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = Color.cyan;
            //GetComponent<Renderer>().material.color = Color.black;
        }

        void Update()
        {
            this.transform.GetChild(0).position = new Vector3(this.transform.GetChild(0).transform.position.x, Mathf.Sin(Time.time * speed), this.transform.GetChild(0).transform.position.z);
            this.transform.GetChild(1).position = new Vector3(this.transform.GetChild(1).transform.position.x, Mathf.Sin(Time.time * speed), this.transform.GetChild(1).transform.position.z);
            if(Mathf.Sin(Time.time * speed) > 0.8){
                GameObject confetti = new GameObject();

            }
        }
    }
}