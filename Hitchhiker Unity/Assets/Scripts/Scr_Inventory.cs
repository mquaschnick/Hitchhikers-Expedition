using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Inventory : MonoBehaviour {

    //public GameObject[,] inventory = new GameObject[5, 5];

    public Button[,] buttons = new Button[5,5];

    public bool isOpen = false;


	// Use this for initialization
	void Start () {

        //inventory = new GameObject[5, 5];
        
        for (int i=0; i<5; i++) {
            for (int j=0; j<5; j++) {
                buttons[i, j] = transform.GetChild(i).GetChild(j).GetComponent<Button>();
            }
        }

        closeInventory();

        //if (inventory[0, 0]) {
        //    buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = inventory[0, 0].tag;
        //} else {
        //    buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = "";
        //}

	}
	
	// Update is called once per frame
	void Update () {

        //if (inventory[0, 0]) {
        //    buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = inventory[0, 0].tag;
        //}
        //else {
        //    buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = "";
        //}

    }


    public void toggleInventory() {
        isOpen = !isOpen;
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                buttons[i, j].gameObject.SetActive(isOpen);
            }
        }

    }

    public void closeInventory() {
        isOpen = false;
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                buttons[i, j].gameObject.SetActive(isOpen);
            }
        }

    }

    public void openInventory() {
        isOpen = true;
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                buttons[i, j].gameObject.SetActive(isOpen);
            }
        }

    }

    public void addFoodItem(GameObject item) {

        Scr_FoodItem foodScript = item.GetComponent<Scr_FoodItem>();

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if(buttons[i, j].transform.GetChild(0).GetComponent<Text>().text == "") {
                    buttons[i, j].transform.GetChild(0).GetComponent<Text>().text = foodScript.itemName;
                    buttons[i, j].onClick.AddListener(delegate { foodScript.consumeItem(i, j); });

                    return;
                }
            }
        }

    }


    public void updateButtons() {
        //for (int i = 0; i < 5; i++) {
            //for (int j = 0; j < 5; j++) {
                //if (inventory[i, j]) {
                //    buttons[i, j].transform.GetChild(0).GetComponent<Text>().text = inventory[i, j].tag;
                //    buttons[i, j].onClick.AddListener(inventory[i, j].GetComponent<Scr_FoodItem>().consumeItem);
                //}
                //else {
               //     buttons[i, j].transform.GetChild(0).GetComponent<Text>().text = "";
                //}
            //}
        //}
    }


}
