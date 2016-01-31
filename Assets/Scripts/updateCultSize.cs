using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class updateCultSize : MonoBehaviour
	{
		public static int score;

		Text scoreText;

		void Awake ()
		{
			scoreText = GetComponent<Text> ();
		}

		// Use this for initialization
		void Start ()
		{
			score = 0;
		}

		// Update is called once per frame
		void Update ()
		{
			scoreText.text = "Cult Size: " + score;
			score++;
		}
	}
}
