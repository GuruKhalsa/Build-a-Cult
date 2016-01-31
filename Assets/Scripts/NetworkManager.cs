using Photon;
using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.PunBehaviour {
	public Camera mainCam;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	public override void OnJoinedLobby ()
	{
		RoomOptions ro = new RoomOptions() {isVisible = true, maxPlayers = 100};
		PhotonNetwork.JoinOrCreateRoom("Cult", ro, TypedLobby.Default);
	}

	public override void OnJoinedRoom ()
	{
		Vector3 startingLocation = new Vector3(-0.31f, 4f, -3.15868f);
		GameObject leader = PhotonNetwork.Instantiate("Leader", startingLocation, Quaternion.identity, 0);
		if(leader.GetPhotonView().isMine){
			mainCam.GetComponent<SmoothCamera2D>().target = leader.transform;
		}
	}
}
