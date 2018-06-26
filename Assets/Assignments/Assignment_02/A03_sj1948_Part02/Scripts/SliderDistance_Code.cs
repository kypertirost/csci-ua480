using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assignment03sj1948Par2
{
    public class SliderDistance_Code : MonoBehaviour
    {
        public GameObject Target;
        private float m_Speed;
        public Slider SliderDis;

        void Start()
        {
        }

        void Update()
        {
            //Control the position of the cube
            Target.transform.position += new Vector3(0.0f, 0.0f,SliderDis.value);
        }
    }
}