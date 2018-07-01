using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ml6468.A04{
    public class Teleport : MonoBehaviour
    {
        /*
         * This script is for part 1. When user select the white circle, he can 
         * directly teleport to that position.
         */
        public GameObject player;
        float playerHeight;

        void Start()
        {
            playerHeight = player.transform.position.y;
        }

        public void TeleportToCircle()
        {
            //move to postion, then rise the height
            player.transform.position = transform.position;
            player.transform.position = new Vector3(player.transform.position.x, playerHeight, player.transform.position.z);
        }

    } 
}

