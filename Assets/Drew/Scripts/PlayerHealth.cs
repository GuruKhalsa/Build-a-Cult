using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public Slider healthSlider;

	private int currentHealth;
	private const int startingHealth = 100;

	void Awake ()
	{
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
		if (currentHealth > healthSlider.minValue) {
			currentHealth -= 10;
		} else if (currentHealth < healthSlider.maxValue) {
			currentHealth += 10;
		} 
		print (currentHealth);
		healthSlider.value = currentHealth;
	}
}