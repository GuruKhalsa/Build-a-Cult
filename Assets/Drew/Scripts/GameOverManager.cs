using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	public Animator animator;
	public Slider healthSlider;

	private int currentHealth;
	private const int startingHealth = 100;

	private static int test = 1;

	void Awake ()
	{
//		animator = GetComponent<Animator> ();
		currentHealth = startingHealth;
	}

	// Use this for initialization
	void Start ()
	{
		healthSlider.value = currentHealth;
	}

	// Update is called once per frame
	void Update ()
	{
		if ((test % 60) == 0) {
			currentHealth -= 10;
		}
		test++;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0) {
			print ("and you dead");
			animator.SetTrigger ("GameOver");
		}
	}

	public int getCurrentHealth ()
	{
		return currentHealth;
	}
}
