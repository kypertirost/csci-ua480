using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ml6468.A02{

    public class InteractController : MonoBehaviour
    {
        public Text Clue;
        public Text winMessage;
        public Text pickUpText;
        private int count;
        // Use this for initialization
        void Start()
        {
            count = 0;
            winMessage.text = "";
            Clue.text = "You can press G to throw an object!";
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GameObject newThrow = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newThrow.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                newThrow.transform.position = transform.GetChild(0).transform.position;
                Rigidbody rb = newThrow.AddComponent<Rigidbody>();

                rb.velocity = transform.forward * 20;
            }
            if (count == 13 && transform.GetChild(0).GetChild(0).GetComponent<Shooting>().GetEnemyNumber() == 0 ){
                winMessage.text = "You Win!";
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                count++;
                pickUpText.text = "Item Picker Up: " + count.ToString() + "/13";
            }
        }




    }
}
