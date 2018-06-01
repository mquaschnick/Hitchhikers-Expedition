using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopingBird : MonoBehaviour {

    public float poopInterval = 3f;
    public float poopIntervalRandomness = 1f;
    public GameObject poop;

    private float poopTimer = 0f;
    private float nextPoopTime;
    private Rigidbody poopRB;

    private bool poopActive = false;

	// Use this for initialization
	void Start () {
        poop.gameObject.SetActive(false);
        nextPoopTime = poopInterval + Random.Range(-poopIntervalRandomness, poopIntervalRandomness);
        poopRB = poop.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        poopTimer += Time.deltaTime;
        if (poopTimer > nextPoopTime)
        {
            if (Mathf.Abs(PlayerController_Master.playerBody.transform.position.x - transform.position.x) <= 25f)
            {
                if (!poopActive)
                    poop.gameObject.SetActive(true);
                Poop();
            }
            if (poopActive)
                poop.gameObject.SetActive(false);
            poopTimer = 0f;
        }
            
	}
    void Poop()
    {
        poop.transform.position = transform.position;
        poop.transform.rotation = transform.rotation;
        poopRB.velocity = Vector3.zero;
        poopRB.angularVelocity = Vector3.zero;

        nextPoopTime = poopInterval + Random.Range(-poopIntervalRandomness, poopIntervalRandomness);
    }
}
