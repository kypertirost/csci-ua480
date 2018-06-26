using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A02_jjo350 {
    public class CameraController : MonoBehaviour
    {

        public float xSens = 5.0f;
        public float ySens = 5.0f;
        public float movementSpeed = 10.0f;
        public float jumpForce = 100.0f;

        private float mouseX;
        private float mouseY;
        private bool jumping;
        private bool jump;
        private Rigidbody rb;

        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            rb = this.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update() {
            
            /*
             * I had 99% of this before, but I didn't think to maintain the mouseX/Y as 
             * private variables.
             * I found out about that here:
             * https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
             */
            mouseX += Input.GetAxis("Mouse X") * xSens;
            mouseY -= Input.GetAxis("Mouse Y") * ySens;

            transform.eulerAngles = new Vector3(mouseY, mouseX, 0);

            if (Input.GetKey("escape")) {
                Cursor.lockState = CursorLockMode.None;
            }

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Jump") && !jumping)
            {
                Debug.Log("jump");
                jump = true;
            }

            Vector3 deltaMove = new Vector3(moveX, 0, moveZ) * Time.deltaTime * movementSpeed;
            Quaternion moveDir = Quaternion.Euler(0, mouseX, 0);
            deltaMove = moveDir * deltaMove;
            transform.position = transform.position + deltaMove;
        }

        private void FixedUpdate()
        {
            if (jump) {
                Debug.Log("jumping");
                jump = false;
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }

            if (transform.position.y < 1.0) {
                jumping = false;
            } else {
                jumping = true;
            }
        }
    }

}
