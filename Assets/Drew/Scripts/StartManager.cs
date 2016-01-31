using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour
{
	public Animator anim;
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
			anim.SetTrigger ("NewGame");
		}
	
	}
}
