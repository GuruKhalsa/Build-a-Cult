using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerNetworkMover : Photon.MonoBehaviour
{
	PhotonView photonView;
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;

	// Use this for initialization
	void Start ()
	{
		photonView = GetComponent<PhotonView> ();
		if (photonView.isMine) {
			GetComponent<ControllerInput> ().enabled = true;
			GetComponent<Player> ().enabled = true;
//			GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
		}
//		gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0.0f, -0.3f,0.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (!photonView.isMine)
//		{
//			transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5);
//			transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, Time.deltaTime * 5);
//		}
	}

	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			// We own this player: send the others our data
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			// Network player, receive data
//			this.correctPlayerPos = (Vector3) stream.ReceiveNext();
//			this.correctPlayerRot = (Quaternion) stream.ReceiveNext();
			this.transform.position = (Vector3)stream.ReceiveNext ();
			this.transform.rotation = (Quaternion)stream.ReceiveNext ();
		}
	}
}
