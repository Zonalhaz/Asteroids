using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject parent;

	public GameObject big_asteroid;
	public float big_asteroidRate;
	public float big_asteroidSpeed;

	public GameObject med_asteroid;
	public float med_asteroidRate;
	public float med_asteroidSpeed;

	public GameObject small_asteroid;
	public float small_asteroidRate;
	public float small_asteroidSpeed;

	float big_asteroidCD;
	float med_asteroidCD;
	float small_asteroidCD;

	public Camera maincam;

	// Update is called once per frame
	void Update () 
	{
		if(big_asteroidCD <= 0)
		{
			big_asteroidCD = big_asteroidRate;
			spawnBig_asteroid();
				
		}
		big_asteroidCD -= Time.deltaTime;

		if(med_asteroidCD <= 0)
		{
			med_asteroidCD = med_asteroidRate;
			spawnMed_asteroid();
			
		}
		med_asteroidCD -= Time.deltaTime;

		if (small_asteroidCD <= 0)
		{
			small_asteroidCD = small_asteroidRate;
			spawnSmall_asteroid();

		}
		small_asteroidCD -= Time.deltaTime;

		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Small");
		if (gos.Length < 15)
		{
			spawnSmall_asteroid();
			spawnSmall_asteroid();
			spawnSmall_asteroid();
			spawnSmall_asteroid();
			spawnSmall_asteroid();
		}
	}

	public void spawnBig_asteroid ()
	{
		float xPos;
		float yPos;
		float randomSpeed = Random.Range(0.5f,1.5f);

		string side = getSide();
		if (side == "left")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x)-5;

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(big_asteroidSpeed*randomSpeed, Random.Range(-3,3)));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "right")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x)+5;

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(-big_asteroidSpeed*randomSpeed, Random.Range(-3,3)));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "top")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y)+5;
			xPos = getX();

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), -big_asteroidSpeed*randomSpeed));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "bottom")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y)-5;
			xPos = getX();

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), big_asteroidSpeed*randomSpeed));
			asteroid.transform.parent = parent.transform;
		}
	}

	public void spawnMed_asteroid ()
	{
		float xPos;
		float yPos;
		float randomSpeed = Random.Range(0.5f,1.5f);
		
		string side = getSide();
		if (side == "left")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x)-5;
			
			GameObject asteroid = (GameObject)Instantiate(med_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(med_asteroidSpeed*randomSpeed, Random.Range(-3,3)));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "right")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x)+5;
			
			GameObject asteroid = (GameObject)Instantiate(med_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(-med_asteroidSpeed*randomSpeed, Random.Range(-3,3)));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "top")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y)+5;
			xPos = getX();
			
			GameObject asteroid = (GameObject)Instantiate(med_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), -med_asteroidSpeed*randomSpeed));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "bottom")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y)-5;
			xPos = getX();
			
			GameObject asteroid = (GameObject)Instantiate(med_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), med_asteroidSpeed*randomSpeed));
			asteroid.transform.parent = parent.transform;
		}
		
		
	}

	public void spawnSmall_asteroid()
	{
		float xPos;
		float yPos;
		float randomSpeed = Random.Range(0.5f, 1.5f);

		string side = getSide();
		if (side == "left")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x) - 5;

			GameObject asteroid = (GameObject)Instantiate(small_asteroid);
			asteroid.transform.position = new Vector3(xPos, yPos, 0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0, 360));
			asteroid.rigidbody2D.AddForce(new Vector2(small_asteroidSpeed * randomSpeed, Random.Range(-3, 3)));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "right")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x) + 5;

			GameObject asteroid = (GameObject)Instantiate(small_asteroid);
			asteroid.transform.position = new Vector3(xPos, yPos, 0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0, 360));
			asteroid.rigidbody2D.AddForce(new Vector2(-small_asteroidSpeed * randomSpeed, Random.Range(-3, 3)));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "top")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y) + 5;
			xPos = getX();

			GameObject asteroid = (GameObject)Instantiate(small_asteroid);
			asteroid.transform.position = new Vector3(xPos, yPos, 0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0, 360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3, 3), -small_asteroidSpeed * randomSpeed));
			asteroid.transform.parent = parent.transform;
		}
		if (side == "bottom")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y) - 5;
			xPos = getX();

			GameObject asteroid = (GameObject)Instantiate(small_asteroid);
			asteroid.transform.position = new Vector3(xPos, yPos, 0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0, 360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3, 3), small_asteroidSpeed * randomSpeed));
			asteroid.transform.parent = parent.transform;
		}


	}

	string getSide ()
	{
		int rand = Random.Range(0,4);
		switch (rand) 
		{
			case(0): 
				return("left");
			case(1): 
				return("top");
			case(2): 
				return("right");
			case(3): 
				return("bottom");
			default:
			return("error");
		}
	}

	float getY ()
	{
		return(Random.Range(maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y, maincam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y));
	}

	float getX ()
	{
		return(Random.Range(maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x, maincam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x));
	}
}






