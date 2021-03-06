﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public GameObject _inventory;
	public Image image;
	public Text text;
	private AudioSource audio;
	public float stealChance;
	public Text moneyText;
	public Sprite merchantNormal;
	public Sprite merchantAngry;
	public AudioClip merchantGreetings;
	public AudioClip merchantYelling;


	void Start()
	{
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
		moneyText.text = "$"+_inventory.GetComponent<Scr_Inventory>().money;

		audio = GetComponent<AudioSource>();
	}

	public void open() {
		Time.timeScale = 0f;
        gameObject.SetActive(true);
		audio.clip = merchantGreetings;
		audio.Play();
	}

	public void close() {
		Time.timeScale = 1f;
        gameObject.SetActive(false);
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
			_inventory.GetComponent<Scr_Inventory>().addMoney(-7);
			moneyText.text = "$"+_inventory.GetComponent<Scr_Inventory>().money;
			image.sprite = merchantAngry;
			text.text = "You dare steal from the trash man! Pay the trash fine!";
			audio.clip = merchantYelling;
		    audio.Play();
		}
	}

	public void exit()
	{
		gameObject.SetActive(false);
	}
}
