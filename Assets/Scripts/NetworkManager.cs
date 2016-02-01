using Photon;
using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.PunBehaviour {
	public Camera mainCam;
	public GameObject[] interactableRespawns;
	string[] interactables = {"Mormon", "Mormon", "Sword", "Flower", "Flower"};

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.2");

		if (interactableRespawns == null)
			interactableRespawns = GameObject.FindGameObjectsWithTag("InteractableSpawn");
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
		GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
		GameObject leader = PhotonNetwork.Instantiate("Leader", spawnPoint.transform.position, Quaternion.identity, 0);
		if(leader.GetPhotonView().isMine){
			mainCam.GetComponent<SmoothCamera2D>().target = leader.transform;
			leader.tag = "Player";
		}
		SpawnInteractables();
	}

	private void SpawnInteractables ()
	{
		interactableRespawns = GameObject.FindGameObjectsWithTag("InteractableSpawn");

		for(int i = 0; i < interactableRespawns.Length; i++) {
			PhotonNetwork.InstantiateSceneObject(interactables[i], interactableRespawns[i].transform.position, interactableRespawns[i].transform.rotation, 0, new object[0]);
		}
	}
}
