using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment02sj1948
{
    public class ButtonPushing : MonoBehaviour
    {
        public GameObject door;
        public bool doorOpened;
        public float speed;
     



        void Update()
        {
            if(doorOpened==true){
                //if the boolean is true then the door opens
                door.transform.Translate(Vector3.up*Time.deltaTime*5);
            }
            //makes sure that the door does up rise up infinitely 
            if(door.transform.position.y>9f){
                doorOpened = false;
            }
        }
        //triggers when left click of the mouse
		private void OnMouseDown()
		{
            doorOpened = true;
		}
	}
}
