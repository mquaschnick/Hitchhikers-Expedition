using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour {

	// Public Variable
	public float baseSpeed = 5.0f;
	public float hitchHikingSpeedMod = 0.5f;

	// Private Variable
	private float _moveMod = 0.0f;
	private float _hitchHikeMod = 1.0f;
	private bool _moving = false;
	private bool _hitchHiking = false;

	// Private Constants
	private const float MOVING = 1.0f;
	private const float STOPPED = 0.0f;
	private const float NOTHITCHHIKING = 1.0f;

	void Update () {
		transform.position -= new Vector3(baseSpeed * _moveMod * _hitchHikeMod * Time.deltaTime, 0.0f, 0.0f);
	}

	public void toggleMove() {
		if (_moving) {
			_moving = false;
			_moveMod = STOPPED;
		} else {
			_moving = true;
			_moveMod = MOVING;
		}
	}

	public void toggleHitchHike() {
		if (_hitchHiking) {
			_hitchHiking = false;
			_hitchHikeMod = NOTHITCHHIKING;
		} else {
			_hitchHiking = true;
			_hitchHikeMod = hitchHikingSpeedMod;
		}
	}
}
