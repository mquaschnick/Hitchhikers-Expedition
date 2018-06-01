using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turd : MonoBehaviour {

    public ParticleSystem splashParticles;
    private AudioSource splashAudio;
    

    // Use this for initialization
    void Awake () {
        splashAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other)
    {
        splashParticles.Emit(20);
        
        transform.position = new Vector3(transform.position.x, -1f, transform.position.z);

        splashAudio.pitch = Random.Range(0.5f, 1.2f);
        splashAudio.Play();
    }
    void OnTriggerEnter(Collider other)
    {
        splashParticles.Emit(20);
        
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController_Statuses.instance.damageDeath(-0.1f);
            PlayerController_Statuses.instance.setDirty(true);
            EventDisplayManager.instance.DisplayMessage("Crap! I'm filthy.");
        }
        transform.position = new Vector3(transform.position.x, -1f, transform.position.z);

        splashAudio.pitch = Random.Range(0.5f, 1.2f);
        splashAudio.Play();
    }
}
