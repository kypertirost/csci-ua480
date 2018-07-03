using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A04{
    public class MoveHandler : MonoBehaviour
    {
        /*
         * 
         * 
         */
        public static MoveHandler Player;
        private float currentSpeed;
        private bool isMoving;

        float speed;


        private void Awake()
        {
            // prevent NullPointer, and set Player to current object
            if (Player == null) {
                Player = this;
            } else if (Player != this) {
                Destroy(this);
            }
            speed = 1.8f;
            isMoving = false;
            currentSpeed = 0.0f;
        }


        // Update is called once per frame
        void Update()
        {
            MoveControl();
        }

        public void MoveControl(){
            if (Input.GetMouseButton(0))
            {
                //holding the mouse, accelerate to full speed
                isMoving = true;

                currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime); // lerp to full speed
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward * currentSpeed * Time.deltaTime);

            }
            else if (isMoving)
            {
                //decelerate
                currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime); // lerp to zero speed
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward * currentSpeed * Time.deltaTime);
                if (currentSpeed - 0.0f < 0.001f)
                {
                    isMoving = false;
                }
            }
        }
  
    }
}

