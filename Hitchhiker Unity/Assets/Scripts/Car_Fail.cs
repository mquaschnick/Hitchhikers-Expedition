using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Fail : MonoBehaviour {

	private float direction;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		if (transform.position.x < player.transform.position.x)
			direction = 1.0f;
		else
			direction = -1.0f;
	}
	
	void Update () {
		transform.position += direction * new Vector3(15.0f * Time.deltaTime, 0.0f, 0.0f);
	}

	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
	}
}
