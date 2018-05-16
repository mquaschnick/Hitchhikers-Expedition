using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_FoodItem : MonoBehaviour {

    public float hungerFill;
    public int width;
    public int height;
    public string itemName;

    //public int positionX = 0;
    //public int positionY = 0;

    public GameObject _player;
    public GameObject _inventory;

	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
    }
	
    public void consumeItem(int startX, int startY) {

        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");

        _player.GetComponent<PlayerController_Statuses>().updateHunger(hungerFill);

        for (int i = startX; i < startX + width; i++) {
            for (int j = startY; j < startY + height; j++) {
                _inventory.GetComponent<Scr_Inventory>().buttons[i, j].transform.GetChild(0).GetComponent<Text>().text = "";
                _inventory.GetComponent<Scr_Inventory>().buttons[i, j].onClick.RemoveAllListeners();
            }
        }

    }
}
