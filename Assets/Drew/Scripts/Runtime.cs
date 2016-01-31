using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Runtime : MonoBehaviour
{
	public static Dictionary<string, GameObject> registeredObjects;

	void Awake ()
	{
		registeredObjects = new Dictionary<string, GameObject> ();
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
