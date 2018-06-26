using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01_cew385
{
    public class ChangeSquares : MonoBehaviour
    {
        float x = 1f, y = 1f, z = 1f;
        float lastTime;
        float newTime;
        // Use this for initialization
        void Start()
        {
            lastTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            newTime = Time.time;
            if (newTime - lastTime > 0.5)
            {
                GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                lastTime = newTime;
            } 
        }
    }
}