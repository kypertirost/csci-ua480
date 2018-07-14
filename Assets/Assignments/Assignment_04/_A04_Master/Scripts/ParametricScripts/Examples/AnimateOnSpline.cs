using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class AnimateOnSpline : MonoBehaviour {

    public Transform[] pos;
    public float t = 0;

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        for (int i = 0; i < 29; i++)
        {
            Gizmos.DrawLine(CatmullRomSpline.GetSplinePos(pos, (float)i/30),
                            CatmullRomSpline.GetSplinePos(pos, ((float)i+1)/30));
        }

    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = CatmullRomSpline.GetSplinePos(pos, Mathf.Clamp(t,0,1));
	}
}
