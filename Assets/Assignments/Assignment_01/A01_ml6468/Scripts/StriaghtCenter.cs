using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ml6468;

public class StriaghtCenter : MonoBehaviour {

    public float distance = 5f;
    public float angle = 10f;

    Transform center;
    Transform ballChild;

    List<Vector3> posList = new List<Vector3>();
    void Start()
    {
        center = transform;
        ballChild = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        center.name = "center";
        ballChild.name = "ball";

        ballChild.position = center.position + Vector3.Normalize(Vector3.up) * distance;

    }



    void Update()
    {
        Quaternion rotate = Quaternion.AngleAxis(angle, Vector3.right);
        Vector3 directionVector = Vector3.Normalize(ballChild.position - center.position);
        Vector3 inwardVector = rotate * directionVector * distance;
        ballChild.position = center.position + inwardVector;

        posList.Add(ballChild.position);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < posList.Count - 1; i++)
        {
            Vector3 from = posList[i];
            Vector3 to = posList[i + 1];
            Gizmos.DrawLine(from, to);
        }
    }
}
