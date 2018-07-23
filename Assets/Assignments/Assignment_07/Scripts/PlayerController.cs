using UnityEngine;
using UnityEngine.Networking;

namespace ml6468 {
    public class PlayerController : NetworkBehaviour {
        /*
         * This is attached to player prefab. It used to bind the camera and 
         * player, and also allow player shoots and moves.
         */
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public GameObject CameraModule;

        private GameObject CameraPrefab;
        private const float ThresholdTime = 0.25f;

        private float time;
        private void Start()
        {
            time = 0;
        }

        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            //bind camera and player prefab
            CameraPrefab.transform.position = transform.position;
            transform.rotation = CameraPrefab.transform.rotation;

            if (Input.GetMouseButtonDown(0)) {
                CmdFire();
            }
            //identify move
            if (Input.GetMouseButton(0)) {
                time += Time.deltaTime;
                if (time > ThresholdTime) {
                    PushMove();
                }
            } else if (Input.GetMouseButtonUp(0)) {
                time = 0.0f;
                ExitMove();
            } 
        }

        // This [Command] code is called on the Client …
        // … but it is run on the Server!
        [Command]
        void CmdFire()
        {
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation
            );

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

            NetworkServer.Spawn(bullet);

            Destroy(bullet, 2.0f);
        }

        public override void OnStartLocalPlayer()
        {
            GameObject empty = new GameObject();
            empty.name = "Combined Player";
            transform.parent = empty.transform;
            CameraModule.transform.parent = transform.parent;

            CameraPrefab = CameraModule.transform.GetChild(0).gameObject;
            transform.forward = CameraPrefab.transform.forward;
            GetComponent<MeshRenderer>().material.color = Color.blue;
            transform.position = CameraPrefab.transform.position;
        }


        private void PushMove() {
            var move = CameraPrefab.transform.forward * Time.deltaTime * 4.0f;
            move.y = 0;
            transform.parent.Translate(move);
        }

        private void ExitMove() {
            transform.parent.Translate(Vector3.zero);
        }

    }
}
