using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_FoodItem : MonoBehaviour {

    public float hungerFill;
    public int width;
    public int height;

    public GameObject _player;
    public GameObject _inventory;

	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
    }
	
    public void consumeItem() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");

        _player.GetComponent<PlayerController_Statuses>().updateHunger(hungerFill);
        _inventory.GetComponent<Scr_Inventory>().buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = "";
        _inventory.GetComponent<Scr_Inventory>().buttons[0, 0].onClick.RemoveAllListeners();

        // REMEBER TO REMOVE after first playable
        _player.GetComponent<PlayerController_Master>().hitchhikingAllowed = true;
    }
}
