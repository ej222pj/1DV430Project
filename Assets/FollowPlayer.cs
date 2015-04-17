using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public float targetX = 0;

	// Update is called once per frame
	void Update () {
		if (GameObject.FindObjectOfType<StartGame> ().hasGameStarted == true) {
			Vector3 pos = transform.position;
			pos.x = Mathf.Lerp (transform.position.x, targetX + 5, 1 * Time.deltaTime);
			transform.position = pos; 
		}
	}
}
