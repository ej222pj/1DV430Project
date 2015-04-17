using UnityEngine;
using System.Collections;

public class MoveFurnitureStartPlatform : MonoBehaviour {

	public float speed;
	public float moveStartPlatformForTime = 15f;
	public float timeInSec = 0f;
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindObjectOfType<StartGame> ().hasGameStarted == true) {
			timeInSec += Time.deltaTime;
			if(timeInSec < moveStartPlatformForTime){
				transform.position += Vector3.left * speed * Time.deltaTime;
			}

			if(GetComponent<EdgeCollider2D>().IsTouchingLayers()){
				GameObject.FindObjectOfType<PlayerMovement>().playerCanJump = true;
			}
		}

	}
}
