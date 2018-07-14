using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04Examples
{
    public class HoldToMove : MonoBehaviour {

    	[Tooltip("Moving speed per second")]
        public float TargetMovingSpeed;

        public bool EasingMovement;

        private float _easingMovementTime = 1.0f;

        private float _currentMovingSpeed = 0.0f;

        private bool _buttonDown = false;

        Rigidbody rb;

    	// Use this for initialization
    	void Start () {
            rb = Camera.main.GetComponent<Rigidbody>();
    	}
    	
		private IEnumerator EaseSpeedToTarget (float target) {
            float t = 0.0f;
            float diff = target - _currentMovingSpeed;
            while (t < _easingMovementTime) {
                t += Time.smoothDeltaTime;
                _currentMovingSpeed = target - diff * (1.0f - t / _easingMovementTime);
                yield return null;
            }
            _currentMovingSpeed = target;
        }


    	// Update is called once per frame
    	void Update () {
            Debug.Log("velocity = " + rb.velocity);
            if (Input.GetMouseButton(0)) {
                if (!_buttonDown) 
                {
                    // User just pressed the button
                    _buttonDown = true;
                    if (EasingMovement)
                    {
                        StartCoroutine(EaseSpeedToTarget(TargetMovingSpeed));
                    }
                    else
                    {
                        _currentMovingSpeed = TargetMovingSpeed;
                    }
                }
            } 
            else if (_buttonDown)
            {
                //User just released the button
                _buttonDown = false;
                if (EasingMovement) 
                {
                    StartCoroutine(EaseSpeedToTarget(0.0f));
                } 
                else 
                {
                    _currentMovingSpeed = 0.0f;
                }
            }

            if (!Mathf.Approximately(_currentMovingSpeed, 0.0f))
            {
                Vector3 camDir = Camera.main.transform.forward;
                camDir.y = 0.0f;
				transform.Translate(camDir.normalized * _currentMovingSpeed * Time.deltaTime, Space.World);
            }

        
    	}
    }
}
