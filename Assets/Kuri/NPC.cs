using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	public string ritualRequest;
	public int belongsToPlayer = 0;
	private int itemSelection;
	public string[] item;
	public Color[] itemColor;
	const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";




	// Use this for initialization
	void Awake () {
	

		itemSelection = Random.Range (0, item.Length);

		int charAmount = Random.Range(3, 16); //set those to the minimum and maximum length of your string

		ritualRequest = "<color=#" + ColorToHex (itemColor [itemSelection]) + ">";

		for(int i=0; i<charAmount; i++)
		{
			ritualRequest += glyphs[Random.Range(0, glyphs.Length)];
		}


		ritualRequest += "</color>";

	}



	string ColorToHex(Color32 color)
	{
		string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		return hex;
	}

}
