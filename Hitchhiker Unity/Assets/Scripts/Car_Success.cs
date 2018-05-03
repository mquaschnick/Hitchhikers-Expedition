using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Car_Success : MonoBehaviour {

	private float direction;
	private GameObject player;
	private float startTime;
	private int count;
	private int delay = 7;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		startTime = Time.time;
		delay *= 60;
	}
	
	void Update () {
		Vector3 playerVector = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		float distCovered = (Time.time - startTime) * 0.15f;
		float journeyLength = Vector3.Distance(transform.position, playerVector);
        float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, playerVector, fracJourney);
		count++;
		if (count > delay)
			SceneManager.LoadScene("Success");
    }

	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
	}
}
