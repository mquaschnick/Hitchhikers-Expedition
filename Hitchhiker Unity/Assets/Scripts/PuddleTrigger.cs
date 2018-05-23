using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleTrigger : MonoBehaviour {

    public ParticleSystem splashParticles;
    private AudioSource splashAudio;
    private PlayerController_Statuses playerStatus;

    private float splashRange = 2f;

	// Use this for initialization
	void Start () {
        splashAudio = GetComponent<AudioSource>();
        playerStatus = PlayerController_Master.playerBody.transform.parent.GetComponent<PlayerController_Statuses>();

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            splashParticles.Emit(50);
            splashAudio.Play();

                        //Detect if player is within range apply GetWet function
            //Something like this depending on how we handle static player to get access to the player position and 

            /*
             if (splashRange > Mathf.Abs (Player.instance.gameObject.transform.position.x - transform.position.x)
                PlayerInventory.instance.WetClothes();
             */

            float distanceFromPlayer = PlayerController_Master.playerBody.transform.position.x - transform.position.x;

            if(Mathf.Abs(distanceFromPlayer) <= splashRange && Mathf.Abs(distanceFromPlayer) >= 0) {
                playerStatus.damageDeath(-0.1f);
            }
          
        }

    }

}
