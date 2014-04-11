using UnityEngine;
using System.Collections;

public class AsteroidControl : MonoBehaviour {

	public string type;
	GameManager gm;

	public GameObject parent;
	public GameObject Med;
	public GameObject Small;

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
        gm = (GameManager)GameObject.Find("_GM").transform.GetComponent("GameManager");
	}
	

	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x > maxX+5 && rigidbody2D.velocity.x >0)
			Destroy(gameObject);
		if (transform.position.x < minX-5 && rigidbody2D.velocity.x <0)
			Destroy(gameObject);

		if (transform.position.y > maxY+5 && rigidbody2D.velocity.y >0)
			Destroy(gameObject);
		if (transform.position.y < minY-5 && rigidbody2D.velocity.y <0)
			Destroy(gameObject);

	}


	void OnTriggerEnter2D (Collider2D thisCollis)
	{

		if (thisCollis.tag == "Bullet")
		{
			if (type == "Big")
			{
				Vector3 pos = transform.position;
				Vector3 deltaPos = new Vector3(.5f,.5f,0);
				Vector2 speed1 = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));

						
				GameObject med1 = (GameObject)Instantiate(Med,pos+deltaPos,Quaternion.identity);
				med1.rigidbody2D.AddForce(speed1*100);
				med1.transform.parent = parent.transform;

				GameObject med2 = (GameObject)Instantiate(Med,pos-deltaPos,Quaternion.identity);
				med2.rigidbody2D.AddForce(-speed1*100);
				med1.transform.parent = parent.transform;

				gm.Score += 20;
				Destroy(gameObject);
				Destroy(thisCollis.gameObject);
				

			}
			if (type == "Med")
			{
				Vector3 pos = transform.position;
				Vector3 deltaPos = new Vector3(.5f, .5f, 0);
				Vector2 speed1 = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));


				GameObject small1 = (GameObject)Instantiate(Small, pos + deltaPos, Quaternion.identity);
				small1.rigidbody2D.AddForce(speed1 * 40);
				small1.transform.parent = parent.transform;

				GameObject small2 = (GameObject)Instantiate(Small, pos - deltaPos, Quaternion.identity);
				small2.rigidbody2D.AddForce(-speed1 * 40);
				small2.transform.parent = parent.transform;

				gm.Score += 50;
				Destroy(gameObject);
				Destroy(thisCollis.gameObject);
			}
			if (type == "Small")
			{
				gm.Score += 100;
				Destroy(gameObject);
				Destroy(thisCollis.gameObject);
			}
		}
	}
}








