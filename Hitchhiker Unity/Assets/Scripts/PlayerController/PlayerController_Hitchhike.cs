using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Hitchhike : MonoBehaviour {

	private PlayerController_Master player;

	// Public Variables
	public int delay = 3;
	public GameObject spawnRight;
	public GameObject spawnLeft;
	public GameObject carFail;
	public GameObject carSuccess;

	// Private Variables
	private int count = 0;
	
	void Start() {
		player = GetComponent<PlayerController_Master>();
		delay *= 60;
	}

	void FixedUpdate() {
		if (count < delay)
			count++;
		else {
			count = 0;
			SpawnCar();
		} 
	}

	
	
	void SpawnCar() {
		float chance = Random.Range(0.0f, 100.0f);
		float percent = player.weather * player.population * 100.0f;
		if (chance <= percent) {
			GameObject car;
			chance = Random.Range(0.0f, 100.0f);
			if (chance <= percent && player.isHitchhiking && carSuccess != null) {
				car = Instantiate(carSuccess, spawnRight.transform.position, spawnRight.transform.rotation);
			} else {
				if (chance <= 50.0f)
					car = Instantiate(carFail, spawnRight.transform.position, spawnRight.transform.rotation);
				else
					car = Instantiate(carFail, spawnLeft.transform.position, spawnLeft.transform.rotation);
			}
			
		}
	}
}