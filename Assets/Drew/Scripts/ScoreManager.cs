using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public class ScoreManager : MonoBehaviour
	{
		public Text scoreText;
		public static int score = 0;

		void Awake ()
		{
		}

		// Use this for initialization
		void Start ()
		{
			score = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
			score++;
			scoreText.text = "Cult Score: " + score;
		}
	}
}