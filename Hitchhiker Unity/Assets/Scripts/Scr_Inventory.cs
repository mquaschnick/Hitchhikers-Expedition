using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Inventory : MonoBehaviour {

    //public GameObject[,] inventory = new GameObject[5, 5];

    public Button[,] buttons = new Button[5,5];
    public GameObject backpack;

    public bool isOpen = false;

    public GameObject startingItem;

    public float money = 20.00f;


	// Use this for initialization
	void Start () {

        //inventory = new GameObject[5, 5];

        backpack = transform.GetChild(0).gameObject;
        money = 20.00f;
        
        for (int i=0; i<5; i++) {
            for (int j=0; j<5; j++) {
                buttons[i, j] = transform.GetChild(i+1).GetChild(j).GetComponent<Button>();
            }
        }

        addClothingItem(startingItem);

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
        backpack.SetActive(isOpen);
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                buttons[i, j].gameObject.SetActive(isOpen);
            }
        }

    }

    public void closeInventory() {
        isOpen = false;
        backpack.SetActive(isOpen);
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                buttons[i, j].gameObject.SetActive(isOpen);
            }
        }

    }

    public void openInventory() {
        isOpen = true;
        backpack.SetActive(isOpen);
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                buttons[i, j].gameObject.SetActive(isOpen);
            }
        }

    }

    public void addFoodItem(GameObject item) {

        Scr_FoodItem foodScript = item.GetComponent<Scr_FoodItem>();
        bool canPlace = true;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if(buttons[i, j].GetComponent<Image>().sprite == null) {
                    canPlace = true;
                    for (int k = i; k < i + foodScript.width; k++) {
                        for (int l = j; l < j + foodScript.height; l++) {
                            if(buttons[k, l].GetComponent<Image>().sprite != null) {
                                canPlace = false;
                            }
                        }
                    }

                    if (canPlace) {
                        for (int m = i; m < i + foodScript.width; m++) {
                            for (int n = j; n < j + foodScript.height; n++) {
                                buttons[m, n].GetComponent<Image>().enabled = true;
                                buttons[m, n].GetComponent<Image>().sprite = foodScript.image;
                                buttons[m, n].onClick.AddListener(delegate { foodScript.consumeItem(m - foodScript.width, n - foodScript.height); });
                            }
                        }

                        return;
                    }
                }
            }
        }

    }

    public void addClothingItem(GameObject item) {

        Scr_ClothingItem clothesScript = item.GetComponent<Scr_ClothingItem>();
        bool canPlace = true;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (buttons[i, j].GetComponent<Image>().sprite == null) {
                    canPlace = true;
                    for (int k = i; k < i + clothesScript.width; k++) {
                        for (int l = j; l < j + clothesScript.height; l++) {
                            if (buttons[k, l].GetComponent<Image>().sprite != null) {
                                canPlace = false;
                            }
                        }
                    }

                    if (canPlace) {
                        for (int m = i; m < i + clothesScript.width; m++) {
                            for (int n = j; n < j + clothesScript.height; n++) {
                                if (m == i && n == j) {
                                    buttons[m, n].GetComponent<Image>().enabled = true;
                                    buttons[m, n].GetComponent<Image>().sprite = clothesScript.image;
                                    buttons[m, n].transform.localScale = new Vector3(clothesScript.width, clothesScript.height, 1);
                                    buttons[m, n].onClick.AddListener(delegate { clothesScript.equipItem(m - clothesScript.width, n - clothesScript.height); });
                                } else {
                                    buttons[m, n].GetComponent<Image>().sprite = clothesScript.image;
                                    //buttons[m, n].GetComponent<Image>().enabled = true;
                                }
                            }
                        }

                        return;
                    }
                }
            }
        }

    }

    public void addMoney(float amount) {
        money += amount;
    }

    public void moveItem(int startX, int startY) {

        //Scr_FoodItem foodScript = item.GetComponent<Scr_FoodItem>();
        bool canPlace = true;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (buttons[i, j].transform.GetChild(0).GetComponent<Text>().text == "") {
                    canPlace = true;
                    //for (int k = i; k < i + foodScript.width; k++) {
                   //     for (int l = j; l < j + foodScript.height; l++) {
                    //        if (buttons[k, l].transform.GetChild(0).GetComponent<Text>().text != "") {
                    //            canPlace = false;
                   //         }
                    //    }
                    //}

                    if (canPlace) {
                        //buttons[i, j].transform.GetChild(0).GetComponent<Text>().text = foodScript.itemName;
                        //buttons[i, j].onClick.AddListener(delegate { foodScript.consumeItem(i, j); });

                        return;
                    }
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
