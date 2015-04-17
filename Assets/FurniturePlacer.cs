using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FurniturePlacer : MonoBehaviour {

	public GameObject[] furniturePrefabs;
	
	public float newFurnitureDelay = 3f;
	public float nextFurniture = 1f;
	public float destroyFurnitureTime = 0f;

	public float FurnitureVelocity = 0f;

	public List<GameObject> furnitureGameObjects = new List<GameObject>();

	
	void Update () {
		if(GameObject.FindObjectOfType<StartGame>().hasGameStarted == true){
			nextFurniture -= Time.deltaTime;
			
			if (nextFurniture <= 0) {
				nextFurniture = newFurnitureDelay;

				GameObject Furniture = (GameObject)Instantiate(furniturePrefabs[Random.Range(0, furniturePrefabs.Length)], transform.position, transform.rotation);
				
				Furniture.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2(0, FurnitureVelocity);

				furnitureGameObjects.Add(Furniture);

				//GameObject.FindObjectOfType<ScoreManager> ().score++;
			}
				if (GameObject.FindObjectOfType<FurnitureDeathTrigger>().destroyFurniture) {

				if(furnitureGameObjects[0] != null){
					Destroy(furnitureGameObjects[0].gameObject);
				}

				furnitureGameObjects.RemoveAt(0);


					GameObject.FindObjectOfType<FurnitureDeathTrigger>().destroyFurniture = false;
				}
		}
	}
}
