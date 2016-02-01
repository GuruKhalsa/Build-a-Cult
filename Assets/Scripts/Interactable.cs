using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
	public GameObject actionableObject;
	private GameObject heldItem;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
			action();
		}
	}

	void action ()
	{
		if (actionableObject != null) {
			if (actionableObject.GetComponent<NPC> () != null) {


//				npcText.GetComponent<Text> ().text = actionableObject.GetComponent<NPC> ().ritualRequest;
//				Debug.Log ("enter");

			}

			if (actionableObject.GetComponent<Door> () != null) {

				gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, actionableObject.GetComponent<Door> ().linkedDoor.transform.position.z);

			}


			if (actionableObject.GetComponent<Item> () != null) {

				if (actionableObject.transform.parent == null) {
					actionableObject.transform.position = transform.GetChild (0).position; //+ new Vector3(0.1f,0.6f,0.5f);
					Debug.Log(actionableObject.name);
					if (actionableObject.name == "Sword(Clone)"){
						actionableObject.transform.Rotate(new Vector3(90,-90, 0));
					}

					actionableObject.transform.parent = transform.GetChild (0);
					heldItem = actionableObject;
					actionableObject = null;
				}



			}
		} else if (heldItem != null) {

			heldItem.transform.parent = null;
			heldItem.GetComponent<Rigidbody> ().isKinematic = false;

			heldItem.transform.position = transform.GetChild (0).position;
//			heldItem.GetComponent<Rigidbody> ().AddForce (new Vector3 (movement.x * heldItem.GetComponent<Item> ().speed * 100f, movement.y + 5f * heldItem.GetComponent<Item> ().speed * 40f, 0f));
			heldItem = null;

		}
	}

	void OnTriggerEnter (Collider col)
	{
		Debug.Log("Near Object");

		if (col.GetComponent<NPC> () != null || col.GetComponent<Door> () || col.GetComponent<Item> ()) {
			actionableObject = col.gameObject;
		}

	}

	void OnTriggerExit (Collider col)
	{


		actionableObject = null;

	}
}
