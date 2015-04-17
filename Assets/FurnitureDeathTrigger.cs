using UnityEngine;
using System.Collections;

public class FurnitureDeathTrigger : MonoBehaviour {

	public bool destroyFurniture = false;
	
	void OnTriggerEnter2D(){
		destroyFurniture = true;
	}
}
