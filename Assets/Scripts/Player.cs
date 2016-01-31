using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net.NetworkInformation;

namespace AssemblyCSharp
{
	
	public class Player : MonoBehaviour
	{

		private bool isGrounded;
		private CharacterController cc;
		private ControllerInput ci;
		private float speed = 12.7f;
		private float jumpLerped = 0f;
		private float jumpLerpTime = 1f;
		private float jumpHeight = 40f;
		public string npcTextToShow = "test";
		private GameObject npcText;
		public GameObject actionableObject;
		private GameObject heldItem;
		private Vector3 movement;
		private float currentHealth;

		public Slider healthSlider;

		void Awake ()
		{
			npcText = GameObject.Find ("NPC Text");

			cc = GetComponent<CharacterController> ();
			ci = GetComponent<ControllerInput> ();

			Camera.main.GetComponent<Follow> ().followedObject = transform;
		}
		
		// Use this for initialization
		void Start ()
		{
			currentHealth = 100;
		}
	
		// Update is called once per frame
		void Update ()
		{
			//	if (!GetComponent<PhotonView> ().isMine) {
		
			//		return;
			//	}

			float nextHealth = currentHealth--;
			healthSlider.value = nextHealth;
	
			gravity ();
		
			jumpLerp ();

			if (ci.JumpDown () && cc.isGrounded) {
				jumpLerpTime = 0f;
			}

			if (ci.actionButtonDown ()) {
				action ();
			}

			movement = new Vector3 (ci.movementX () * speed, jumpLerped, 0f);

			cc.Move (movement * Time.deltaTime);
		}

		void gravity ()
		{
			cc.Move (Vector3.down * 18f * Time.deltaTime);
		}

		void jumpLerp ()
		{
			jumpLerped = Mathf.Lerp (jumpHeight, 0f, jumpLerpTime);
			jumpLerpTime += Time.deltaTime * 3f;
		}

		void action ()
		{
			if (ci.actionButtonDown ()) {
				if (actionableObject != null) {
					if (actionableObject.GetComponent<NPC> () != null) {
						npcText.GetComponent<Text> ().text = actionableObject.GetComponent<NPC> ().ritualRequest;
						Debug.Log ("enter");
					}

					if (actionableObject.GetComponent<Door> () != null) {
						gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, actionableObject.GetComponent<Door> ().linkedDoor.transform.position.z);
					}

					if (actionableObject.GetComponent<Item> () != null) {
						if (actionableObject.transform.parent == null) {
							actionableObject.transform.position = transform.GetChild (0).position;

							actionableObject.transform.parent = transform.GetChild (0);
							heldItem = actionableObject;
							actionableObject = null;
						}
					}
				} else if (heldItem != null) {
					heldItem.transform.parent = null;
					heldItem.GetComponent<Rigidbody> ().isKinematic = false;
				
					heldItem.transform.position = transform.GetChild (0).position;
					heldItem.GetComponent<Rigidbody> ().AddForce (new Vector3 (movement.x * heldItem.GetComponent<Item> ().speed * 100f, movement.y + 5f * heldItem.GetComponent<Item> ().speed * 40f, 0f));
					heldItem = null;
				}
			}
		}

		void OnTriggerEnter (Collider col)
		{
			if (col.GetComponent<NPC> () != null || col.GetComponent<Door> () || col.GetComponent<Item> ()) {
				actionableObject = col.gameObject;
			}
		}

		void OnTriggerExit (Collider col)
		{
			actionableObject = null;
		}
	}
}