using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public float bulletSpeed;
	public GameObject parent;
	public GameObject bullet;

	public GameObject ship;

	// Use this for initialization
	public void shoot ()
	{
		Vector3 pos = ship.transform.position + (ship.transform.up/3);
		GameObject Fbullet = (GameObject)Instantiate(bullet,pos,Quaternion.identity);
		Fbullet.rigidbody2D.AddForce(ship.transform.up*bulletSpeed);
		Fbullet.transform.parent = parent.transform;
	}
}
