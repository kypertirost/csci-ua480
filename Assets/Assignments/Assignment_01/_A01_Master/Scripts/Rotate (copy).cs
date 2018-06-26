using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public Vector3 beginning;
    public Vector3 end;
    float counter;
    // properties
    // Transform transform
    // GameObject gameObject
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        counter += Time.deltaTime;
        //Debug.Log(transform.eulerAngles);

        // calculate rotation for each frame
        transform.position = Vector3.Lerp(beginning, end, counter);
	}
}
