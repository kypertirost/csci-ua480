using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A04{
    public class MoveHandler : MonoBehaviour
    {
        /*
         * This script is for part 2. User can push the button to accelerate
         * to full speed, and release the button to deaccelerate to the rest.
         */
        private float currentSpeed;
        private bool isMoving;
        private float speed;
        // Update is called once per frame
        private void Start()
        {
            speed = 2.0f;
            isMoving = false;
            currentSpeed = 0;
        }
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                //holding the mouse, accelerate to full speed
                Debug.Log("click");
                isMoving = true;
                currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime); // lerp to full speed
                Debug.Log(currentSpeed);
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward * currentSpeed * Time.deltaTime);

            }
            else if (isMoving)
            {
                //deaccelerate
                currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime); // lerp to zero speed
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;
                transform.Translate(forward * currentSpeed * Time.deltaTime);
                if (currentSpeed - 0.0f < 0.001f)
                {
                    // prevent huge calculation, stop execute if speed is undetectable
                    isMoving = false;
                }
            }
        }

        public void MoveControl(){
            
        }
  
    }
}

