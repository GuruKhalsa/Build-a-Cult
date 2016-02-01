using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.tag == "Enemy"){
			Debug.Log("STABBED ENEMY");
			col.GetComponent<PhotonView>().RPC("GetHit",PhotonTargets.All, 25f, PhotonNetwork.player.name);
		}

		if(col.GetComponent<NPC>()){
			Debug.Log("stabbed NPC");
		}
	}
}
