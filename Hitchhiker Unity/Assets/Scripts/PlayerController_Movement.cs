using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Movement : MonoBehaviour {

	private PlayerController_Master player;

	// Private Variables
	private float _moveMod = 0.0f;
	private float _hitchHikeMod = 1.0f;

	// Private Constants
	private const float MOVING = 1.0f;
	private const float STOPPED = 0.0f;
	private const float NOTHITCHHIKING = 1.0f;

	void Start () {
		player = GetComponent<PlayerController_Master>();
		player.isMoving = false;
		player.isHitchhiking = false;
	}

	void Update () {
		transform.position -= new Vector3(player.baseSpeed * _moveMod * _hitchHikeMod * Time.deltaTime, 0.0f, 0.0f);
	}

	public void toggleMove() {
		player.isMoving = !player.isMoving;
		if (player.isMoving)
			_moveMod = MOVING;
		else
			_moveMod = STOPPED;
	}

	public void toggleHitchHike() {
		player.isHitchhiking = !player.isHitchhiking;
		if (player.isHitchhiking)
			_hitchHikeMod = player.hitchHikingSpeedMod;
		else
			_hitchHikeMod = NOTHITCHHIKING;
	}
}
