using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Inventory : MonoBehaviour {

    public GameObject[,] inventory;

    public Button[,] buttons = new Button[5,5];


	// Use this for initialization
	void Start () {

        inventory = new GameObject[5, 5];
        
        for (int i=0; i<5; i++) {
            for (int j=0; j<5; j++) {
                buttons[i, j] = transform.GetChild(i).GetChild(j).GetComponent<Button>();
            }
        }

        buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = "Hello";

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
