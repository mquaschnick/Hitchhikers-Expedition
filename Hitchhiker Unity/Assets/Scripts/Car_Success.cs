using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Car_Success : MonoBehaviour {

	private float direction;
	private GameObject player;
	private float startTime;
	private int count;
	private float delay = 5;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<PlayerController_Movement>().getInCar();

        startTime = Time.time;
        delay = Mathf.Floor(Random.Range(300, 600));
	}
	
	void Update () {
		Vector3 playerVector = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
		float distCovered = (Time.time - startTime) * 0.15f;
		float journeyLength = Vector3.Distance(transform.position, playerVector);
        float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(transform.position, playerVector, fracJourney);
		count++;
        if (count > delay) {
            player.GetComponent<PlayerController_Movement>().getOutCar();
            player.transform.SetParent(null);
            Destroy(gameObject);
        }
    }

	void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            player.GetComponent<PlayerController_Movement>().getInCar();
            player.transform.SetParent(transform);
        }
        else if (other.gameObject.tag == "Despawner") {
            Destroy(gameObject);
        }
	}


}
