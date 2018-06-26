using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment02sj1948
{
	
public class ProjectileShooter : MonoBehaviour {
	public GameObject prefab;
	public Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		prefab=Resources.Load("Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			GameObject projectile=Instantiate(prefab) as GameObject;
			projectile.transform.position=transform.position+Camera.main.transform.forward*2;
			rb=projectile.GetComponent<Rigidbody>();
			rb.velocity=Camera.main.transform.forward*speed;
			Destroy(projectile,1f);
		}
	}
}
}
