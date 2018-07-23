using UnityEngine;
using UnityEngine.Networking;

namespace ml6468.A07{
    public class EnemyController : NetworkBehaviour
    {
        // this script is attached to enemy prefab so that enemy can move, shoot 
        // repeatly in a given interval.
        public GameObject bulletPrefab;
        public Transform bulletSpawn;

        void Start()
        {
            // repeat rotate and fire per round
            InvokeRepeating("RandomRotate", 0.5f, 5.0f);
            InvokeRepeating("CmdFire", 0.5f, 1.5f);
        }

        void Update()
        {
            RandomMove();
        }

        void RandomMove()
        {
            var z = Random.Range(0, .1f);
            transform.Translate(0, 0, z);
        }
        void RandomRotate()
        {
            var x = Random.Range(0, 360);
            transform.Rotate(0, x, 0);
        }

        [Command]
        void CmdFire()
        {
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
            NetworkServer.Spawn(bullet);
            Destroy(bullet, 2.0f);
        }

    }

}
