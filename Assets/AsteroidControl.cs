using UnityEngine;
using System.Collections;

public class AsteroidControl : MonoBehaviour {

	public string type;
	
	public GameObject Med;

	public Camera maincam;
	
	float maxY;
	float minY;
	float maxX;
	float minX;



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
		if (transform.position.x > maxX && rigidbody2D.velocity.x >0)
			Destroy(gameObject);
		if (transform.position.x < minX && rigidbody2D.velocity.x <0)
			Destroy(gameObject);

		if (transform.position.y > maxY && rigidbody2D.velocity.y >0)
			Destroy(gameObject);
		if (transform.position.y > maxY && rigidbody2D.velocity.y <0)
			Destroy(gameObject);

	}

	void OnTriggerEnter2D (Collider2D thisCollis)
	{

		if (thisCollis.tag == "Bullet")
		{
			if (type == "Big")
			{
				Vector2 speed = new Vector2(rigidbody2D.velocity.x*300,rigidbody2D.velocity.y*300);
				Vector3 pos = transform.position;
				Vector3 deltaPos = new Vector3(1f,1f,0);
				Vector2 speed1;

				int choose = Random.Range(0,5);
				switch (choose) {
					case(0):
						speed1 = new Vector2(speed.x,speed.y);
						break;
					default:
						break;
			}
					speed1 = new Vector2(speed.x,-speed.y);
					speed1 = new Vector2(-speed.x,speed.y);

				GameObject med1 = (GameObject)Instantiate(Med,pos+deltaPos,Quaternion.identity);
				med1.rigidbody2D.AddForce(speed1);

				GameObject med2 = (GameObject)Instantiate(Med,pos-deltaPos,Quaternion.identity);
				med2.rigidbody2D.AddForce(-speed1);
				Destroy(gameObject);
			}
		}
	}
}








