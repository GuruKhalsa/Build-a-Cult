using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public float speed = 1f;
	public float damage = 1f;
	public int belongsToPlayer;


	void Awake(){
		Rigidbody rb = gameObject.AddComponent<Rigidbody> ();
		rb.constraints = RigidbodyConstraints.FreezePositionZ;
		rb.isKinematic = true;




	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.GetComponent<NPC>()){
			Debug.Log("Bumped into NPC");
		}
	}
}
