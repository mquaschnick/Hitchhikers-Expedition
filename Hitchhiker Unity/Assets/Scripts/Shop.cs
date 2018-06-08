using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public GameObject _inventory;
	public float stealChance;
	public Text moneyText;

	void Start()
	{
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
		moneyText.text = "$"+_inventory.GetComponent<Scr_Inventory>().money;
	}

	// public void tryPay(float cost)
	// {
	// 	_inventory.GetComponent<Scr_Inventory>().addMoney(-1*cost);
	// 	moneyText.text = "$"+_inventory.GetComponent<Scr_Inventory>().money;
	// }

	public void buy(GameObject item)
	{
		float itemCost = item.GetComponent<Scr_FoodItem>().shopCost;
		float currentMoney = _inventory.GetComponent<Scr_Inventory>().money;

		if(itemCost <= currentMoney)
		{
			_inventory.GetComponent<Scr_Inventory>().addFoodItem(item);
			_inventory.GetComponent<Scr_Inventory>().addMoney(-itemCost);
			moneyText.text = "$"+_inventory.GetComponent<Scr_Inventory>().money;
		}
	}

	public void steal(GameObject item)
	{
		float rand = Random.Range(1,100);

		if(rand <= stealChance)
			_inventory.GetComponent<Scr_Inventory>().addFoodItem(item);
		else
		{
			exit();
		}
	}

	public void exit()
	{
		gameObject.SetActive(false);
	}
}
