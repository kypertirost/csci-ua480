using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment01sj1948
{
    public class Follow : MonoBehaviour
    {

        public GameObject target;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(target.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 20 * Time.deltaTime);
        }
    }
}