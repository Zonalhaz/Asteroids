using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	public KeyCode turnLeft;
	public KeyCode turnRight;

	public float turnRate;
	public float speed;
	
	// Update is called once per frame
	void Update () 
	{

		Vector2 vely = new Vector2(0,0);
		if (Input.GetKey(moveUp))
			rigidbody2D.AddForce(new Vector2(0,speed));

		if (Input.GetKey(moveDown))
			rigidbody2D.AddForce(new Vector2(0,-speed));

		if (Input.GetKey(moveLeft))
			rigidbody2D.AddForce(new Vector2(-speed,0));

		if (Input.GetKey(moveRight))
			rigidbody2D.AddForce(new Vector2(speed,0));
		/*
		if (Input.GetKeyUp(turnLeft))
		{
		    rigidbody2D.fixedAngle = true;
		    rigidbody2D.fixedAngle = false;
		}
		if (Input.GetKeyUp(turnRight))
		{
			rigidbody2D.fixedAngle = true;
			rigidbody2D.fixedAngle = false;
		}
		*/

		if (Input.GetKey(turnLeft))
			rigidbody2D.AddTorque(Mathf.PI*turnRate);

		if (Input.GetKey(turnRight))
			rigidbody2D.AddTorque(Mathf.PI*turnRate*-1);
	}
}
