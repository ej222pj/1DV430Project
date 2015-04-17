using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public bool hasGameStarted = false;
	public bool hasUserClickedFirstTimeToStart = false;

	// Update is called once per frame
	void Update () {
		if (GameObject.FindObjectOfType<KillPlayer>().hasLost == false) {
			if (Input.GetMouseButtonDown (0)) {
				hasUserClickedFirstTimeToStart = true;
			}

			if (hasUserClickedFirstTimeToStart == false) {
				hasGameStarted = false;
			}

			if (hasUserClickedFirstTimeToStart == true) {
				hasGameStarted = true;
			}
		}
	}
}
