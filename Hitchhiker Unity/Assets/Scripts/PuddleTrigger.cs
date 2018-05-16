using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleTrigger : MonoBehaviour {

    public ParticleSystem splashParticles;
    private AudioSource splashAudio;

    private float splashRange = 2f;

	// Use this for initialization
	void Start () {
        splashAudio = GetComponent<AudioSource>();
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
          
        }

    }
}
