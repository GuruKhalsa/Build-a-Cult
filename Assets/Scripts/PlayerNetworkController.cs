using UnityEngine;
using System.Collections;

public class PlayerNetworkController : Photon.MonoBehaviour {
	public delegate void Respawn(float time);
	public event Respawn RespawnMe;
	PhotonView photonView;
	Vector3 correctPlayerPos;
	Quaternion correctPlayerRot;

	private Vector3 latestCorrectPos;
	private Vector3 onUpdatePos;
	private float fraction;

	float smoothing = 10f;
	float health = 100f;

	bool initialLoad = true;

	// Use this for initialization
	void Start () {
		this.latestCorrectPos = transform.position;
		this.onUpdatePos = transform.position;

		photonView = GetComponent<PhotonView>();
		if(photonView.isMine)
		{
			GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
			GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
			GetComponent<Interactable>().enabled = true;
			GetComponent<Rigidbody>().isKinematic = false;
		}
//		gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, -0.3f,0.0f);
	}
	
	// Update is called once per frame
//	void Update()
//	{
//		if (!photonView.isMine)
//		{
////			StartCoroutine("UpdateData");
//			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
//			transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
//		}
//	}
	public void Update()
	{
		if (this.photonView.isMine)
		{
			return;     // if this object is under our control, we don't need to apply received position-updates 
		}

		// We get 10 updates per sec. Sometimes a few less or one or two more, depending on variation of lag.
		// Due to that we want to reach the correct position in a little over 100ms. We get a new update then.
		// This way, we can usually avoid a stop of our interpolated cube movement.
		//
		// Lerp() gets a fraction value between 0 and 1. This is how far we went from A to B.
		//
		// So in 100 ms, we want to move from our previous position to the latest known. 
		// Our fraction variable should reach 1 in 100ms, so we should multiply deltaTime by 10.
		// We want it to take a bit longer, so we multiply with 9 instead!

		this.fraction = this.fraction + Time.deltaTime * 9;
		transform.localPosition = Vector3.Lerp(this.onUpdatePos, this.latestCorrectPos, this.fraction); // set our pos between A and B
	}

//	IEnumerator UpdateData()
//	{
//		if(initialLoad)
//		{
//			initialLoad = false;
//			transform.position = position;
//			transform.rotation = rotation;
//
//			//      mainCam.rotation = mainCamRotation;
//			//      mainCam.Rotate(0, mainCamRotation.y, 0);
//
//		}
//
//		while(true)
//		{
//			transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
//			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smoothing);
//			//      mainCam.rotation = Quaternion.Lerp(mainCam.rotation, mainCamRotation, Time.deltaTime * smoothing);
//			yield return null;
//		}
//	}

//	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//	{
//		if (stream.isWriting)
//		{
//			// We own this player: send the others our data
//			stream.SendNext(transform.position);
//			stream.SendNext(transform.rotation);
//			stream.SendNext(health);
//		}
//		else
//		{
//			// Network player, receive data
////			this.correctPlayerPos = (Vector3) stream.ReceiveNext();
////			this.correctPlayerRot = (Quaternion) stream.ReceiveNext();
//			this.transform.position = (Vector3) stream.ReceiveNext();
//			this.transform.rotation = (Quaternion) stream.ReceiveNext();
//			health = (float)stream.ReceiveNext();
//		}
//	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 pos = transform.localPosition;
			Quaternion rot = transform.localRotation;
			stream.Serialize(ref pos);
			stream.Serialize(ref rot);
		}
		else
		{
			// Receive latest state information
			Vector3 pos = Vector3.zero;
			Quaternion rot = Quaternion.identity;

			stream.Serialize(ref pos);
			stream.Serialize(ref rot);

			this.latestCorrectPos = pos;                // save this to move towards it in FixedUpdate()
			this.onUpdatePos = transform.localPosition; // we interpolate from here to latestCorrectPos
			this.fraction = 0;                          // reset the fraction we alreay moved. see Update()

			transform.localRotation = rot;              // this sample doesn't smooth rotation
		}
	}


	[PunRPC]
	public void GetHit(float damage, string enemyName)
	{
		health -= damage;
		if(health <= 0 && photonView.isMine)
		{
			Debug.Log(PhotonNetwork.player.name + " was killed by " + enemyName);

			if(RespawnMe != null)
				RespawnMe(3f);
			PhotonNetwork.Destroy (gameObject);
		}
	}
}