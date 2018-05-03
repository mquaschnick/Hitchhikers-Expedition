using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEnvironment : MonoBehaviour {

	//List of potential drops from interaction
	[SerializeField]
	protected GameObject[] itemDrops;

	//If the object has been interacted with
	protected bool used = false;

	//Reference to the player object
	[SerializeField]
	private GameObject _player;

	//Offset to place object above player model
	public float yOffset = 2;

	//Delay in seconds before object is destroyed
	public int delay = 5;
	
	// Update is called once per frame
	void Update () {

		//When mouse is pressed
		if(Input.GetMouseButtonDown(0)){
			//Variable to store the result of the Raycast
			RaycastHit hit;
			//Ray from the camera to the mouse pointer
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//Check if hit by ray trace from camera to mouse
			if (Physics.Raycast(ray, out hit)){
				//Check if already been interacted with
				if (!used) {
					//Mark as used
					used = true;

					//Get random gameobject from potential drops list
					GameObject drop = itemDrops[Random.Range(0, itemDrops.Length)];
					//Get the player model location
					Vector3 loc = _player.transform.position;
					//Translate up by yOffset Units
					loc.y += yOffset;

					//Create game object above players head
					GameObject instance = Instantiate(drop, loc, _player.transform.rotation);

					//Set the parent of the game object to the player
					//This ensures the object remains above the players head
					instance.transform.SetParent(_player.transform);

					//Destroy the gameobject after 5 seconds
					Destroy(instance, delay);
				}
			}
		}
	}
}
