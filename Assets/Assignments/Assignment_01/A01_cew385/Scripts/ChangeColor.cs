using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01_cew385
{
    public class ChangeColor : MonoBehaviour
    {
        //GameObject parent;
        //GameObject child1;
        //GameObject child2;
        float x = 1f, y = 1f, z = 1f;
        float lastTime;
        float newTime;
        // Use this for initialization
        void Start()
        {
            //child1 = parent.transform.GetChild(0).gameObject;
            //child2 = parent.transform.GetChild(1).gameObject;
            lastTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            newTime = Time.time;
            if (newTime - lastTime > 0.5)
            {
                //GetComponentInChildren<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                this.transform.GetChild(1).GetComponent<MeshRenderer>().material.color = this.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
                //child2.GetComponent<Material>().color = child1.GetComponent<Material>().color;
                lastTime = newTime;
            }
        }
    }
}