using UnityEngine;
using System.Collections;

public class MoveFurniture : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		if (GameObject.FindObjectOfType<StartGame> ().hasGameStarted == true) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if(GetComponent<EdgeCollider2D>().IsTouchingLayers()){
			GameObject.FindObjectOfType<PlayerMovement>().playerCanJump = true;
		}
	}
}
