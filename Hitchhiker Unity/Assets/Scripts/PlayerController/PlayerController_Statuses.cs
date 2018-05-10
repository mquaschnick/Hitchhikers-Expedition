using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Statuses : MonoBehaviour {

    private PlayerController_Master player;

    public Slider hungerBar;
    public Slider thirstBar;

    public float tickTime = 10.0f;
    private float _tickTime;

    void Start() {
        player = GetComponent<PlayerController_Master>();
        _tickTime = Time.time + tickTime;
    }

    private void Update() {


        if (Time.time > _tickTime) {
            updateHunger(player.starveRate);
            updateThirst(player.thirstRate);

            _tickTime = Time.time + tickTime;
        }
    }

    public void updateHunger(float amount) {

        player.hunger += amount;
        if (player.hunger > 1) {
            player.hunger = 1;
        }
        else if (player.hunger < 0) {
            player.hunger = 0;
        }
        hungerBar.value = player.hunger;
    }

    public void updateThirst(float amount) {

        player.thirst += amount;
        if (player.thirst > 1) {
            player.thirst = 1;
        }
        else if (player.thirst < 0) {
            player.thirst = 0;
        }
        thirstBar.value = player.thirst;
    }

}
