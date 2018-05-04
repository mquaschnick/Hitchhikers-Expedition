﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Statuses : MonoBehaviour {

    private PlayerController_Master player;

    public Slider hungerBar;

    void Start() {
        player = GetComponent<PlayerController_Master>();
    }

    //private void Update() {
        //updateHunger(player.starveRate * Time.deltaTime);
    //}


    public void updateHunger(float amount) {

        player.hunger += amount;
        hungerBar.value = player.hunger;
    }

}