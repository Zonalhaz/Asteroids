using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject big_asteroid;
	public float big_asteroidRate;
	public float big_asteroidSpeed;

	float big_asteroidCD;

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
		}
		if (side == "right")
		{
			yPos = getY();
			xPos = (maincam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x)+5;

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(-big_asteroidSpeed*randomSpeed, Random.Range(-3,3)));
		}
		if (side == "top")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y)+5;
			xPos = getX();

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), -big_asteroidSpeed*randomSpeed));
		}
		if (side == "bottom")
		{
			yPos = (maincam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y)-5;
			xPos = getX();

			GameObject asteroid = (GameObject)Instantiate(big_asteroid);
			asteroid.transform.position = new Vector3(xPos,yPos,0);
			asteroid.transform.Rotate(Vector3.forward * Random.Range(0,360));
			asteroid.rigidbody2D.AddForce(new Vector2(Random.Range(-3,3), big_asteroidSpeed*randomSpeed));
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






