using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_ClothingItem : MonoBehaviour {

    public int width;
    public int height;
    public string itemName;
    public Sprite image;

    //public int positionX = 0;
    //public int positionY = 0;

    public GameObject _player;
    public GameObject _inventory;

    void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    public void equipItem(int startX, int startY) {

        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");

        PlayerController_Master.playerBody.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);

        for (int i = startX; i < startX + width; i++) {
            for (int j = startY; j < startY + height; j++) {
                _inventory.GetComponent<Scr_Inventory>().buttons[i, j].GetComponent<Image>().sprite = null;
                _inventory.GetComponent<Scr_Inventory>().buttons[i, j].transform.localScale = new Vector3(1, 1, 1);
                _inventory.GetComponent<Scr_Inventory>().buttons[i, j].GetComponent<Image>().enabled = false;
                _inventory.GetComponent<Scr_Inventory>().buttons[i, j].onClick.RemoveAllListeners();
            }
        }

    }
}
