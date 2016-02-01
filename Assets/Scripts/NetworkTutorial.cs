//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using System.Linq;
//
//public class NetworkTutorial : MonoBehaviour {
//	[SerializeField] Text connectionText;
//	[SerializeField] Transform[] spawnPoints;
//	[SerializeField] Camera sceneCamera;
//
//	[SerializeField] GameObject serverWindow;
//	[SerializeField] InputField username;
//	[SerializeField] InputField roomName;
//	[SerializeField] InputField roomList;
//	[SerializeField] InputField messageWindow;
//
//	public Toggle generalToggle;
//	public Toggle squaddieToggle;
//
//	[SerializeField] GameObject generalWindow;
//	[SerializeField] Camera overheadCam;
//
//	[SerializeField] GameObject squaddieWindow;
//
//	[SerializeField] ToggleGroup playerToggleGroup;
//	[SerializeField] Toggle playerTogglePrefab;
//	GameObject spawnPrefab;
//
//	Vector3 spawnPosition;
//	Quaternion spawnRotation;
//
//	[SerializeField] ToggleGroup buildingToggleGroup;
//
//	public Dictionary<Toggle, int> playerPhotonIds { get; set; }
//	Dictionary<Toggle, GameObject> buildingOptions;
//	Dictionary<Toggle, Camera> playerCameras;
//
//	GameObject player;
//	Queue<string> messages;
//	const int messageCount = 6;
//	PhotonView photonView;
//
//	GameObject buildingFoundation = null;
//	Vector3? buildingFoundationLocation = null;
//	[SerializeField] Material hutOpaque;
//
//	[SerializeField] GameObject woodenHut;
//	[SerializeField] GameObject woodenTower;
//	[SerializeField] Toggle woodenHutToggle;
//	[SerializeField] Toggle woodenTowerToggle;
//
//	// Use this for initialization
//	void Start () {
//		photonView = GetComponent<PhotonView>();
//		spawnPrefab = GameObject.Find("SpawnPoint");
//
//		woodenHutToggle.group = buildingToggleGroup;
//		woodenTowerToggle.group = buildingToggleGroup;
//		buildingOptions = new Dictionary<Toggle, GameObject>();
//		buildingOptions.Add (woodenHutToggle, woodenHut);
//		buildingOptions.Add (woodenTowerToggle, woodenTower);
//
//
//		//		PhotonNetwork.isMessageQueueRunning = false;
//		PhotonNetwork.logLevel = PhotonLogLevel.Full;
//		PhotonNetwork.ConnectUsingSettings("0.1");
//		StartCoroutine("UpdateConnectionString");
//	}
//
//	void Update () {
//		//very inefficient! move this section to the end of spawnPlayer call 
//		//		if(generalToggle.isOn){
//		//			GameObject[] players = GameObject.FindGameObjectsWithTag("player");
//		//			foreach(GameObject fpsplayer in players)
//		//			{
//		//				PhotonPlayer fpsOwner = fpsplayer.GetPhotonView().owner;
//		//				Toggle playerToggle = playerPhotonIds.FirstOrDefault(x => x.Value == fpsOwner.ID).Key;
//		//				playerToggle.onValueChanged.AddListener(delegate {ValueChangeCheck (fpsplayer, playerToggle);});
//		//			}
//		//		}
//
//		Vector3 point = overheadCam.ScreenToViewportPoint(Input.mousePosition);
//		if (point.x >= 0 && point.x <= 1 && point.y >= 0 && point.y <= 1) {
//
//			if(Input.GetKeyDown(KeyCode.F)){
//				// This may not be the correct way to compare the rect object in C#
//				if(overheadCam.rect == new Rect(0.5f, 0.5f, 0.5f, 0.5f)){
//					overheadCam.rect = new Rect(0, 0, 1, 1);
//					//					generalWindow.SetActive(false);
//					generalWindow.transform.localScale = new Vector3(0, 0, 0);
//					sceneCamera.enabled = false;
//				}
//				else{
//					overheadCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
//					//					generalWindow.SetActive(true);
//					generalWindow.transform.localScale = new Vector3(1, 1, 1);
//					sceneCamera.enabled = true;
//				}
//			}
//
//			Ray ray = overheadCam.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//
//			if(Physics.Raycast(ray, out hit))
//			{
//
//				Toggle activeBuildToggle = buildingToggleGroup.ActiveToggles().FirstOrDefault();
//
//
//
//				if(Input.GetKey(KeyCode.P) && Input.GetKeyDown(KeyCode.Mouse0))
//				{
//					GameObject spawnMarker = Instantiate(spawnPrefab, new Vector3(hit.point.x,hit.point.y + 2.5f,hit.point.z), Quaternion.identity) as GameObject;
//					//					foreach(Toggle toggle in playerToggleGroup.ActiveToggles())
//					//					{
//					//						Debug.Log ("SKITTLES");
//					//					}
//					Toggle activeToggle = playerToggleGroup.ActiveToggles().FirstOrDefault();
//					setSpawnPoint(playerPhotonIds[activeToggle], spawnMarker.transform.position, spawnMarker.transform.rotation);
//
//
//				}
//				else if(Input.GetKey(KeyCode.B) && Input.GetKeyDown(KeyCode.Mouse0)){
//					//					if(buildingFoundation != null){
//					//						Destroy (buildingFoundation as GameObject);
//					//						buildingFoundation = null;
//					//					}
//					if(buildingFoundationLocation != null){
//						//						Material[] materials = buildingFoundation.GetComponent<Renderer>().materials;
//						//						Material[] intMaterials = new Material[materials.Length];
//						//						for(int i=0;i<materials.Length;i++){
//						////							Color color = materials[i].color;
//						////							color.a = 1.0f;
//						////							intMaterials[i].SetColor("_Color", color);
//						//							Debug.Log ("Materials/" + materials[i].name.Replace(" (Instance)", "") + "_Opaque");
//						//							Material opaqueMaterial = Instantiate(Resources.Load("Materials/" + materials[i].name.Replace(" (Instance)", "") + "_Opaque", typeof(Material))) as Material;//Instantiate(Resources.Load("/Materials/" + intMaterials[i].name + "_Opaque")) as Material;
//						//							intMaterials[i] = opaqueMaterial;
//						//						}
//						//
//						//						buildingFoundation.GetComponent<Renderer>().materials = intMaterials;
//
//						//
//						//						foreach(Material material in buildingFoundation.GetComponent<Renderer>().materials){
//						//							Color color = material.color;
//						//							color.a = 1.0f;
//						//							material.SetColor("_Color", color);
//						//							Material opaqueMaterial = Resources.Load("/Materials/" + material.name + "_Opaque") as Material;
//						//							material = opaqueMaterial;
//						//						}
//						PhotonNetwork.Instantiate(buildingOptions[activeBuildToggle].name, buildingFoundationLocation.GetValueOrDefault(), buildingFoundation.transform.rotation, 0);
//						buildingFoundation = null;
//						//					Instantiate(buildingOptions[activeBuildToggle], new Vector3(hit.point.x,hit.point.y, hit.point.z), Quaternion.identity);
//					}
//				}
//				else if(Input.GetKeyDown(KeyCode.B))
//				{ 
//					buildingFoundationLocation = new Vector3(hit.point.x,hit.point.y, hit.point.z);
//					buildingFoundation = Instantiate(buildingOptions[activeBuildToggle], buildingFoundationLocation.GetValueOrDefault(), Quaternion.identity) as GameObject;
//					Material[] materials = buildingFoundation.GetComponent<Renderer>().materials;
//					Material[] intMaterials = new Material[materials.Length];
//					for(int i=0;i<materials.Length;i++){
//						Debug.Log (materials[i].name);
//						Debug.Log ("Materials/" + materials[i].name.Replace("_Opaque (Instance)", ""));
//						Material transparentMaterial = Instantiate(Resources.Load("Materials/" + materials[i].name.Replace("_Opaque (Instance)", ""), typeof(Material))) as Material;//Instantiate(Resources.Load("/Materials/" + intMaterials[i].name + "_Opaque")) as Material;
//						intMaterials[i] = transparentMaterial;
//						Color color = materials[i].color;
//						color.a = 0.001f;
//						intMaterials[i].SetColor("_Color", color);
//					}
//					buildingFoundation.GetComponent<Renderer>().materials = intMaterials;
//
//					//					Color color = buildingFoundation.GetComponent<Renderer>().material.color;
//					//					color.a = 0.001f;
//					//					buildingFoundation.GetComponent<Renderer>().material.SetColor("_Color", color);
//				}
//				if(Input.GetKey(KeyCode.R)){
//					if(buildingFoundation != null){
//						buildingFoundation.transform.Rotate(0,2,0);
//					}
//				}
//				if(Input.GetKeyUp(KeyCode.B)){
//					if(buildingFoundation != null){
//						Destroy (buildingFoundation as GameObject);
//						buildingFoundation = null;
//					}
//				}
//			}
//		}
//	}
//
//	void ToggleChanged(Toggle toggle){
//
//	}
//
//	// Update is called once per frame
//	IEnumerator UpdateConnectionString () {
//		while(true){
//			connectionText.text = PhotonNetwork.connectionStateDetailed.ToString();
//			yield return null;
//		}
//	}
//
//	void OnJoinedLobby()
//	{
//		serverWindow.SetActive(true);
//	}
//
//
//	void OnReceivedRoomListUpdate()
//	{
//		roomList.text = "";
//		RoomInfo[] rooms = PhotonNetwork.GetRoomList();
//		foreach(RoomInfo room in rooms)
//			roomList.text += room.name + "\n";
//	}
//
//	public void JoinRoom()
//	{
//		PhotonNetwork.player.name = username.text;
//		RoomOptions ro = new RoomOptions() {isVisible = true, maxPlayers = 10};
//		PhotonNetwork.JoinOrCreateRoom(roomName.text, ro, TypedLobby.Default);
//
//	}
//
//	void OnJoinedRoom()
//	{
//		//		PhotonNetwork.isMessageQueueRunning = true;
//		serverWindow.SetActive(false);
//		StopCoroutine("UpdateConnectionString");
//		connectionText.text = "";
//		if(generalToggle.isOn){
//			generalWindow.SetActive(true);
//			overheadCam.enabled = true;
//			overheadCam.gameObject.SetActive(true);
//			overheadCam.rect = new Rect (0.5f, 0.5f, 0.5f, 0.5f);
//			sceneCamera.enabled = false;
//			sceneCamera.gameObject.SetActive(false);
//			UpdatePlayerList_RPC();
//			//			StartCoroutine("UpdateRoomPlayerList");
//		}
//		else{
//			UpdatePlayerList();
//			squaddieWindow.SetActive(true);
//			overheadCam.enabled = true;
//			//			StartSpawnProcess(0f);
//		}
//	}
//
//	//	void OnLeftRoom()
//	//	{
//	//		if(generalToggle.isOn){
//	//		}
//	//		else{
//	//			UpdatePlayerList_RPC();
//	//		}
//	//	}
//
//	void OnPhotonPlayerDisconnected(PhotonPlayer player)
//	{
//		if(generalToggle.isOn){
//			UpdatePlayerList_RPC();
//		}
//	}
//
//	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
//	{
//		//		if (stream.isWriting)
//		//		{
//		//			stream.SendNext(transform.position);
//		//			stream.SendNext(transform.rotation);
//		//			stream.SendNext(health);
//		//		}
//		//		else
//		//		{
//		//			position = (Vector3)stream.ReceiveNext();
//		//			rotation = (Quaternion)stream.ReceiveNext();
//		//			health = (float)stream.ReceiveNext();
//		//		}
//	}
//
//	//	public Camera GetCameraForMousePosition() {
//	//		Camera[] allCameras = Object.FindObjectsOfType(typeof(Camera)) as Camera[];
//	//		foreach (Camera camera in allCameras) {
//	//			Vector3 point = camera.ScreenToViewportPoint(Input.mousePosition);
//	//			if (point.x >= 0 && point.x <= 1 && point.y >= 0 && point.y <= 1) {
//	//				return camera;
//	//			}
//	//		}
//	//		return null;
//	//	}
//
//	void StartSpawnProcess (float respawnTime)
//	{
//		sceneCamera.enabled = true;
//		StartCoroutine("SpawnPlayer", respawnTime);
//	}
//
//	IEnumerator SpawnPlayer(float respawnTime)
//	{
//		yield return new WaitForSeconds(respawnTime);
//
//		//		Get user's actorID and use that to update a spawnPoint variable that is set on their local machine
//
//		if(Object.Equals(spawnPosition, default(Vector3)) || Object.Equals(spawnRotation, default(Quaternion)))
//		{
//			int index = Random.Range(0, spawnPoints.Length);
//			spawnPosition = spawnPoints[index].position;
//			spawnRotation = spawnPoints[index].rotation;
//		}
//		player = PhotonNetwork.Instantiate("FPSPlayer", spawnPosition, spawnRotation, 0);
//
//		//		if (respawns == null)
//		//			respawns = GameObject.FindGameObjectsWithTag("Respawn");
//		//		
//		//		foreach (GameObject respawn in respawns) {
//		//			Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
//		//		}
//
//
//		player.GetComponent<PlayerNetworkMover>().RespawnMe += StartSpawnProcess;
//		player.GetComponent<PlayerNetworkMover>().SendNetworkMessage += AddMessage;
//		playerCameras = new Dictionary<Toggle, Camera>();
//		sceneCamera.enabled = false;
//		sceneCamera.gameObject.SetActive(false);
//
//		AddMessage("Spawned Player: " + PhotonNetwork.player.name);
//	}
//
//	void AddMessage(string message)
//	{
//		photonView.RPC ("AddMessage_RPC", PhotonTargets.All, message);
//	}
//
//	public void BattlePhase()
//	{
//		photonView.RPC("BattlePhase_RPC", PhotonTargets.All);
//	}
//
//	void UpdatePlayerList()
//	{
//		photonView.RPC ("UpdatePlayerList_RPC", PhotonTargets.All);
//	}
//
//	void setSpawnPoint(int playerID, Vector3 spawningPosition, Quaternion spawningRotation)
//	{
//		PhotonPlayer player = PhotonPlayer.Find(playerID);
//		photonView.RPC ("SetSpawnPoint_RPC", player, spawningPosition, spawningRotation);
//	}
//
//	[PunRPC]
//	void AddMessage_RPC(string message)
//	{
//		messages.Enqueue(message);
//		if(messages.Count > messageCount)
//			messages.Dequeue();
//		messageWindow.text = "";
//		foreach(string m in messages)
//			messageWindow.text += m + "\n";
//	}
//
//	[PunRPC]
//	void BattlePhase_RPC()
//	{
//		if(squaddieToggle.isOn)
//		{
//			squaddieWindow.SetActive(false);
//			StartSpawnProcess(0f);
//		}
//		//		else
//		//		{
//		//			//execute once squaddie spawn process coroutine is complete
//		//			GameObject[] players = GameObject.FindGameObjectsWithTag("player");
//		//			foreach(GameObject fpsplayer in players)
//		//			{
//		//				PhotonPlayer fpsOwner = fpsplayer.GetPhotonView().owner;
//		//				Toggle playerToggle = playerPhotonIds.FirstOrDefault(x => x.Value == fpsOwner.ID).Key;
//		//				playerToggle.onValueChanged.AddListener(delegate {ValueChangeCheck (fpsplayer, playerToggle);});
//		//			}
//		//		}
//	}
//
//	public void ValueChangeCheck(GameObject fpsPlayer, Toggle playerToggle)
//	{
//		if(generalToggle.isOn){
//			//			if(playerToggle.isOn){
//			foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")){
//				foreach(Camera camera in player.GetComponentsInChildren<Camera>()){
//					camera.enabled = false;
//				}
//			}
//			Camera playerCam = fpsPlayer.GetComponent<Camera>();
//			foreach(Camera camera in fpsPlayer.GetComponentsInChildren<Camera>()){
//				camera.enabled = true;
//			}
//			sceneCamera = playerCam;
//			//			}
//		}
//	}
//
//	[PunRPC]
//	void SetSpawnPoint_RPC(Vector3 spawningPosition, Quaternion spawningRotation)
//	{
//		spawnPosition = spawningPosition;
//		spawnRotation = spawningRotation;
//	}
//
//	[PunRPC]
//	void UpdatePlayerList_RPC()
//	{
//		if(generalToggle.isOn)
//		{
//			playerPhotonIds = new Dictionary<Toggle, int>();
//
//			GameObject[] playerToggles = GameObject.FindGameObjectsWithTag("PlayerToggle");
//			foreach(GameObject playerToggle in playerToggles)
//			{
//				Destroy (playerToggle);
//			}
//
//			int toggleOffset = 0;
//			foreach(PhotonPlayer player in PhotonNetwork.playerList)
//			{
//				Debug.Log ("Skittles");
//				Debug.Log (player.allProperties);
//				Toggle toggle = Instantiate(playerTogglePrefab);
//				toggle.transform.SetParent(generalWindow.transform, false);
//				toggle.group = playerToggleGroup;
//				toggle.GetComponentInChildren<Text>().text = player.name;
//				Vector3 togglePositionAdjustment = new Vector3(0, toggleOffset * -20f, 0);
//				toggle.transform.position += togglePositionAdjustment;
//				playerPhotonIds.Add(toggle, player.ID);
//
//				// Try using player.customProperties to save spawn point and other information
//				// player.SetCustomProperties();
//				//				player.SetTeam(PunTeams.Team
//
//				//				player.
//				//
//				//				playerCameras.Add(toggle);
//
//				toggleOffset += 1;
//			}
//		}
//	}
//
//	//	[PunRPC]
//	//	void UpdatePlayerCameraList_RPC(Camera playerCamera)
//	//	{
//	//		if(generalToggle.isOn)
//	//		{
//	//			
//	////			GameObject[] playerToggles = GameObject.FindGameObjectsWithTag("PlayerToggle");
//	////			foreach(GameObject playerToggle in playerToggles)
//	////			{
//	////				Destroy (playerToggle);
//	////			}
//	//
//	//
//	//			foreach(KeyValuePair<string, string> entry in playerPhotonIds)
//	//			{
//	//				entry.Key;
//	//			}
//	//
//	//			int toggleOffset = 0;
//	//			foreach(PhotonPlayer player in PhotonNetwork.playerList)
//	//			{
//	//
//	//				Toggle toggle = Instantiate(playerTogglePrefab);
//	//				toggle.transform.SetParent(generalWindow.transform, false);
//	//				toggle.group = playerToggleGroup;
//	//				toggle.GetComponentInChildren<Text>().text = player.name;
//	//				Vector3 togglePositionAdjustment = new Vector3(0, toggleOffset * -20f, 0);
//	//				toggle.transform.position += togglePositionAdjustment;
//	//				playerPhotonIds.Add(toggle, player.ID);
//	//				
//	//				// Try using player.customProperties to save spawn point and other information
//	//				// player.SetCustomProperties();
//	//				//				player.SetTeam(PunTeams.Team
//	//				
//	//				//				player.
//	//				//
//	//				//				playerCameras.Add(toggle);
//	//				
//	//				toggleOffset += 1;
//	//			}
//	//		}
//	//	}
//}
//
//
