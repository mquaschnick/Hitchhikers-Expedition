using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Statuses : MonoBehaviour {

    public static PlayerController_Statuses instance;
    private PlayerController_Master player;
    

    public Slider hungerBar;
    public Slider thirstBar;
    public Slider D34THBar;

    public GameObject D34DScreen;
    public GameObject dirtyObjects;

    public float tickTime = 10.0f;
    private float _tickTime;

    void Start() {
        instance = this;
        player = GetComponent<PlayerController_Master>();
        _tickTime = Time.time + tickTime;
    }

    private void Update() {


        if (Time.time > _tickTime) {
            updateHunger(player.starveRate);
            updateThirst(player.thirstRate);
            updateD34TH(player.D34THRate);

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

    public void updateD34TH(float amount) {

        if (player.thirst <= .2f) {
            player.D34TH += amount;
        }
        if (player.hunger <= .2f) {
            player.D34TH += amount;
        }

        if (player.thirst >= .8f && player.hunger >= .8f) {
            player.D34TH -= amount;
        }
        
        if (player.D34TH > 1) {
            player.D34TH = 1;
        }
        
        D34THBar.value = player.D34TH;
        if (player.D34TH < 0) {
           Time.timeScale = 0;
           D34DScreen.SetActive(true);
        }
    }

    public void damageDeath(float amount) {

        player.D34TH += amount;

        if (player.D34TH > 1) {
            player.D34TH = 1;
        }

        D34THBar.value = player.D34TH;
        if (player.D34TH < 0) {
            Time.timeScale = 0;
            D34DScreen.SetActive(true);
        }
    }
    public void setDirty(bool isDirty)
    {
        dirtyObjects.SetActive(isDirty);
        player.isDirty = isDirty;
    }

}
