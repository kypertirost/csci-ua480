using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ml6468.A03{
    [RequireComponent(typeof(Canvas))]
    public class MenuControl : MonoBehaviour
    {
        /*
         * The following code is modified version of class example MenuCanvasController
         */
        float distanceToCamera;
        Canvas myCanvas;
        bool isShow;
        GameObject controllObject;


        // Use this for initialization
        void Start()
        {
            Hide();
            isShow = false;
            Vector3 dis = Camera.main.transform.position - transform.position;
            distanceToCamera = Vector3.Project(dis, Camera.main.transform.forward).magnitude;

        }

        private void SetChildrenActive(bool isActive)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(isActive);
            }
        }

        public void Show(GameObject sender)
        {
            if (isShow)
            {
                Hide();
            }

            controllObject = sender;
            if (!transform.tag.Equals("Slider")){
                transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanceToCamera;
                transform.forward = Camera.main.transform.forward;
            }
            SetChildrenActive(true);
            isShow = true;


        }

        public void Hide()
        {
            controllObject = null;
            SetChildrenActive(false);
            isShow = false;
        }



    }
}

