using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Inventory : MonoBehaviour {

    public string[][] inventory;


	// Use this for initialization
	void Start () {

        inventory = new string[10][];

        for (int i = 0; i < inventory.Length; i++) {
            inventory[i] = new string[10];
        }

	}
	
	// Update is called once per frame
	void Update () {
		


	}
}
