using UnityEngine;
using System.Collections;


public class GameEngine : MonoBehaviour {

	public GameObject[] spawns;
	public GameObject[] spawnableObjects;

	void Awake(){

		spawns = GameObject.FindGameObjectsWithTag ("Respawn");

	int spawnPoint =	Random.Range (0,spawns.Length);



		//GameObject self = PhotonNetwork.Instantiate ("Player", GameObject.Find("Spawn Point").transform.position, Quaternion.identity, 0);
//		GameObject self = Instantiate (Resources.Load("Player"), spawns[spawnPoint].transform.position, Quaternion.identity) as GameObject;

//		for (int i = 0; i < spawns.Length; i++) {
//		
//			int itemIndex = Random.Range((-spawnableObjects.Length/2), spawnableObjects.Length);
//			if(itemIndex > -1){
//			Instantiate (spawnableObjects[itemIndex], spawns[i].transform.position, Quaternion.identity);
//			}
//
//		}

		//make if note for if player is owner of all objects to maintain while playing



	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
