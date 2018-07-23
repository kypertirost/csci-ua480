using UnityEngine;
using System.Collections;
namespace ml6468.A07{
    public class Billboard : MonoBehaviour
    {
        // this is attached to health bar so that it always faces towards player

        public GameObject camPrefab;
        void Update()
        {
            transform.LookAt(camPrefab.GetComponentInChildren<Camera>().transform);
        }
    }
}
