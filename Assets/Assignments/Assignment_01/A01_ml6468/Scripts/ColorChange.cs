using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ml6468
{
    public class ColorChange : MonoBehaviour
    {

        public Color fadeIn = Color.white;
        public Color fadeOut = Color.red;
        public float dur = 3.0f;
        Color lerpedColor = Color.white;

        private float time = 0;
        private bool max;
        private new Renderer renderer;
        // Use this for initialization
        void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        void Update()
        {
            //from white to red
            //idea from https://docs.unity3d.com/ScriptReference/Color.Lerp.html
            this.lerpedColor = Color.Lerp(fadeIn, fadeOut, time);
            this.renderer.material.color = lerpedColor;

            if (max)
            {
                this.time = this.time - Time.deltaTime / dur;
            }
            else
            {
                this.time = this.time + Time.deltaTime / dur;

            }
            if (time > 0.99f || time < 0.01f)
            {
                max = !max;
            }
        }

    }
}