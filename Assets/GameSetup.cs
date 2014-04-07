using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	public GameManager gm;
	// Use this for initialization
	void Start () 
	{
		gm.spawnBig_asteroid();
		gm.spawnBig_asteroid();
		gm.spawnMed_asteroid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
