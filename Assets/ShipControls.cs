using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour {
	

	public KeyCode turnLeft;
	public KeyCode turnRight;
	public KeyCode forward;

	public float turnRate;
	public float speed;

	public Camera maincam;

	float maxY;
	float minY;
	float maxX;
	float minX;

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
		if (Input.GetKey(turnLeft))
			transform.Rotate(Vector3.forward * +turnRate);

		if (Input.GetKey(turnRight))
			transform.Rotate(Vector3.forward * -turnRate);

		if (Input.GetKey(forward))
			rigidbody2D.AddForce(transform.up*speed);

		if(rigidbody2D.velocity.x > 10)
			rigidbody2D.velocity = new Vector2(10, rigidbody2D.velocity.y);
		if(rigidbody2D.velocity.x < -10)
			rigidbody2D.velocity = new Vector2(-10, rigidbody2D.velocity.y);

		if(rigidbody2D.velocity.y > 10)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 10);
		if(rigidbody2D.velocity.y < -10)
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -10);

		if (transform.position.y > maxY)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - maxY*2);
		}
		if (transform.position.y < minY)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + maxY*2);
		}
		if (transform.position.x > maxX)
		{
			transform.position = new Vector3(transform.position.x -maxY*2.7f, transform.position.y);
		}
		if (transform.position.x < minX)
		{
			transform.position = new Vector3(transform.position.x + maxY*2.7f, transform.position.y);
		}
	}
}







