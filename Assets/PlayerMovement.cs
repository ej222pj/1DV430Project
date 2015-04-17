using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float forwardSpeed;
	public float downSpeed = 5f;
	public float jumpSpeed = 10f;

	public bool didUserPressJump = false;
	public bool playerCanJump = false;

	public float jumpTime = 0f;
	public float timeAllowedInAir = 1f;

	void FixedUpdate()
	{
		if (GameObject.FindObjectOfType<StartGame> ().hasGameStarted == true) {
			transform.position += Vector3.down * downSpeed * Time.deltaTime;
		}
	}

	void Update() 
	{
		if (GameObject.FindObjectOfType<StartGame> ().hasGameStarted == true) {

			Camera.main.GetComponent<FollowPlayer> ().targetX = transform.position.x + forwardSpeed;

			transform.position += Vector3.right * forwardSpeed * Time.deltaTime;

			//Räknar upp tiden i luften
			if(didUserPressJump == true && jumpTime < timeAllowedInAir){
				jumpTime += Time.deltaTime;
			}

			//Avaktiverar hoppet om man varit i luften för länge
			if (jumpTime > timeAllowedInAir) {
				didUserPressJump = false;
			}

			//Hoppar om man trycker på skärmen
			if (Input.GetMouseButtonDown (0)) {
				if (jumpTime < timeAllowedInAir && playerCanJump) {
					didUserPressJump = true;
				}
			}
			//Slutar hoppa om man släpper skärmen
			if (Input.GetMouseButtonUp (0)) {
				jumpTime = 0;
				didUserPressJump = false;
			}

			if (didUserPressJump) {
				transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
			}

			playerCanJump = false;
		}
	}

	void LateUpdate () {
		var left = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
		var right = Camera.main.ViewportToWorldPoint(Vector3.one).x;
		//var top = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
		var top = Camera.main.ViewportToWorldPoint(Vector3.one).y;
		float x = transform.position.x, y = transform.position.y;
		if (transform.position.x <= left + GetComponent<Renderer>().bounds.extents.x) {
			x = left + GetComponent<Renderer>().bounds.extents.x;
		} else if (transform.position.x >= right - GetComponent<Renderer>().bounds.extents.x) {
			x = right - GetComponent<Renderer>().bounds.extents.x;
		}
		//if (transform.position.y <= top + GetComponent<Renderer>().bounds.extents.y) {
		//	y = top + GetComponent<Renderer>().bounds.extents.y;
		//} else 
		if (transform.position.y >= top - GetComponent<Renderer>().bounds.extents.y) {
			y = top - GetComponent<Renderer>().bounds.extents.y;
		}
		transform.position = new Vector3(x, y, transform.position.z);
	}
}
