using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Car_Success : MonoBehaviour {

	private float direction;
	private GameObject player;
    private GameObject eventManager;
	private float startTime;
	private int count;
	private float delay = 5;
    public float offset = 0;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<PlayerController_Movement>().getInCar();
        eventManager = GameObject.FindGameObjectWithTag("EventManager");
        startTime = Time.time;
        offset = 0;
        delay = Mathf.Floor(Random.Range(900, 1300));
	}

    public void setOffset(float num) {
        offset = num;
    }
	
	void FixedUpdate () {
		Vector3 playerVector = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
		float distCovered = (Time.time - startTime) * 0.025f;
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
            eventManager.GetComponent<Event_HitchToTheHike>().HitchToTheHikeYN();
        }
        else if (other.gameObject.tag == "Despawner") {
            Destroy(gameObject);
        }
	}

}
