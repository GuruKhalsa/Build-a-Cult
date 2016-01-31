using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform followedObject;

	// Update is called once per frame
	void Update () {
	

		Vector3 newPosition = new Vector3 (followedObject.position.x,followedObject.position.y, (followedObject.position.z - 10f));
		transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime * 2.33f);

	}
}
