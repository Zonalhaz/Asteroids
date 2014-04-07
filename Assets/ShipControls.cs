using UnityEngine;
using System.Collections;

public class ShipControls : MonoBehaviour {

    public GameManager gm;
    //Deadness
    public int lives = 3;
    private float invinceCD;
    private bool dead = false;

	public KeyCode turnLeft;
	public KeyCode turnRight;
	public KeyCode forward;
	public KeyCode shoot;
	
	public float turnRate;
	public float speed;
	public float maxSpeed;
	public float shootRate;
	float shootCD;

	public Camera maincam;

	float maxY;
	float minY;
	float maxX;
	float minX;

	public ShootScript shootScript;

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
        invinceCD -= Time.deltaTime;
        if (!dead)
        {
            //Check for keypresses
            if (Input.GetKey(turnLeft))
                transform.Rotate(Vector3.forward * +turnRate);

            if (Input.GetKey(turnRight))
                transform.Rotate(Vector3.forward * -turnRate);

            if (Input.GetKey(forward))
                rigidbody2D.AddForce(transform.up * speed);

            if (Input.GetKey(shoot) & shootCD < 0)
            {
                shootScript.shoot();
                shootCD = shootRate;
            }
            shootCD -= Time.deltaTime;
            //Ensures speed stays below 10
            if (rigidbody2D.velocity.x > maxSpeed)
                rigidbody2D.velocity = new Vector2(maxSpeed, rigidbody2D.velocity.y);
            if (rigidbody2D.velocity.x < -maxSpeed)
                rigidbody2D.velocity = new Vector2(-maxSpeed, rigidbody2D.velocity.y);

            if (rigidbody2D.velocity.y > maxSpeed)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed);
            if (rigidbody2D.velocity.y < -maxSpeed)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -maxSpeed);

            //Makes screenregion loop
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - maxY * 2);
            }
            if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + maxY * 2);
            }
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(transform.position.x - maxY * 2.7f, transform.position.y);
            }
            if (transform.position.x < minX)
            {
                transform.position = new Vector3(transform.position.x + maxY * 2.7f, transform.position.y);
            }
        }
	}

	IEnumerator OnTriggerEnter2D(Collider2D thisCollis)
	{
		if (thisCollis.tag == "Big" || thisCollis.tag == "Med" || thisCollis.tag == "Small" && invinceCD <= 0)
		{
            if (lives > 0)
            {

                gameObject.transform.position = maincam.ScreenToWorldPoint(new Vector3(-30f, 15, 0f));
                dead = true;
                invinceCD = 2;
                yield return new WaitForSeconds(1);
                lives--;
                gameObject.transform.position = new Vector3(0, 0, 0);
                dead = false;

            }
		}
	}

    void Respawn ()
    {

    }

}







