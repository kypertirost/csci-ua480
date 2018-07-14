using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerping : MonoBehaviour {

    public Transform[] ctrl;
    public float t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = DumbSpline(Mathf.Clamp01(t));
	}

    Vector3 DumbSpline(float t){

        Vector3 A = Vector3.Lerp(ctrl[0].position, ctrl[1].position, t);
        Vector3 B = Vector3.Lerp(ctrl[1].position, ctrl[2].position, t);
        return Vector3.Lerp(A, B, t);
    }
}
