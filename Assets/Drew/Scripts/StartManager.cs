using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour
{
	public Animator anim;
	public StateManager state;
	Canvas canvas;

	// Use this for initialization
	void Start ()
	{
		canvas = GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			canvas.enabled = false;
			triggerNewGame ();
		}
	}

	public void triggerNewGame ()
	{
		Debug.Log ("start");
		anim.SetTrigger ("NewGame");
	}
}
