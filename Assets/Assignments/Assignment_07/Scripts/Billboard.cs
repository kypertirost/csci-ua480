using UnityEngine;
using System.Collections;
namespace ml6468.A07{
    public class Billboard : MonoBehaviour
    {

        void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}
