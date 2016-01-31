using UnityEngine;
using UnityEditor;
using System;

public class PauseManager : MonoBehaviour
{
	public Animator anim;
	Canvas canvas;
	public StateManager state;

	// Use this for initialization
	void Start ()
	{
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			canvas.enabled = !canvas.enabled;

			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		}
	}

	public void Quit ()
	{
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else 
			Application.Quit();
		#endif
	}
}