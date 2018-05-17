﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Master : MonoBehaviour {

	// Public Variables
	public float baseSpeed = 3.0f;
	public float hitchHikingSpeedMod = 0.5f;
    public float hunger = 0.6f; // 0 starving, 1 full
    public float starveRate = -0.0001f;
	public float weather = 1.0f;
	public float population = 0.5f;
	public bool isMoving;
	public bool isHitchhiking;
	public bool hitchhikingAllowed = false;

}