using UnityEngine;
using UnityEditor;
using System;

public class PauseManager : MonoBehaviour
{
	public Animator anim;
	//	CanvasRenderer rend;
	Canvas canvas;
	private static Boolean paused = false;

	// Use this for initialization
	void Start ()
	{
		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;
//		rend = GetComponent<CanvasRenderer> ();
//		rend.SetAlpha (0f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
			canvas.enabled = !canvas.enabled;
//			if (paused) {
//				rend.SetAlpha (1f);
//			} else {
//				rend.SetAlpha (0f);
//			}

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