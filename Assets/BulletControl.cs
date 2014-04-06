using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	float maxY;
	float minY;
	float maxX;
	float minX;

	public Camera maincam;

	// Use this for initialization
	void Start () 
	{
		maxY = maincam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y ;
		minY = maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y;
		maxX = maincam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x ;
		minX = maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
			Destroy(gameObject);
	}
}
