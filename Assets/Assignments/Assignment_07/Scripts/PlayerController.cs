using UnityEngine;
using UnityEngine.Networking;

namespace ml6468 {
    public class PlayerController : NetworkBehaviour {
        
        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        private void Start()
        {
            GameObject empty = new GameObject();
            transform.parent = empty.transform;
            Camera.main.transform.parent = transform.parent;
            transform.forward = Camera.main.transform.forward;
        }

        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            //bind camera and player prefab
            var transformPosition = transform.position;
            transformPosition.y = 0.39f;
            Camera.main.transform.position = transformPosition;
            transform.rotation = Camera.main.transform.rotation;

            //identify move or shoot
            if (Input.GetMouseButtonDown(0)) {
                transform.parent.Translate(Vector3.zero);
                CmdFire();
            } else if (Input.GetMouseButtonUp(0)) {
                ExitMove();
            } else if (Input.GetMouseButton(0)) {
                PushMove();
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
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }



        private void PushMove() {
            var move = Camera.main.transform.forward * Time.deltaTime * 4.0f;
            move.y = 0;
            transform.parent.Translate(move);
        }

        private void ExitMove() {
            transform.parent.Translate(Vector3.zero);
        }

    }
}
