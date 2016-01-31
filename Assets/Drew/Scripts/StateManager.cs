using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
	// constants
	private const int startingHealth = 100;

	// state
	private static Boolean paused;
	private int currentHealth = startingHealth;

	public Animator anim;
	public Slider healthSlider;

	// test
	private static int test = 1;

	void Awake ()
	{
	}

	// Use this for initialization
	void Start ()
	{
		currentHealth = startingHealth;
		paused = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((test % 60) == 0) {
			currentHealth -= 5;
		}
		test++;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			print ("and you dead");
			anim.SetTrigger ("GameOver");
		}	
	}

	public int getCurrentHealth ()
	{
		return currentHealth;
	}

	public void Pause ()
	{
		
	}
}
