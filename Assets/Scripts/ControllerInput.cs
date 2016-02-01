using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {

	public KeyCode jumpButton = KeyCode.Space;
	public KeyCode attackButton = KeyCode.F;
	public KeyCode actionButton = KeyCode.G;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool actionButtonDown(){
	
	
		if (Input.GetKeyDown (actionButton))
			return true;
		else
			return false;
	
	}





	public bool JumpDown(){


		if (Input.GetKeyDown (jumpButton))
			return true;
		else
			return false;

	}


	public bool attacking(){

		if (Input.GetKey (attackButton))
			return true;
		else
			return false;


	}


	public bool attackDown(){

		if (Input.GetKeyDown (attackButton))
			return true;
		else
			return false;



	}

	public bool attackUp(){

		if (Input.GetKeyUp (attackButton))
			return true;
		else
			return false;


	}


	public bool jumpUp(){

		if (Input.GetKeyUp (jumpButton))
			return true;
		else
			return false;



	}



	public float movementX(){

		return Input.GetAxis ("Horizontal");


	}

	public float movementY(){
		
		return Input.GetAxis ("Vertical");


	}




}
