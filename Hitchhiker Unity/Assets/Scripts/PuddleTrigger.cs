using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleTrigger : MonoBehaviour {

    public ParticleSystem splashParticles;
    private AudioSource splashAudio;
    private PlayerController_Statuses playerStatus;

    private float splashRange = 1.7f;

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

            float distanceFromPlayer = PlayerController_Master.playerBody.transform.position.x - transform.position.x;

            if (Mathf.Abs(distanceFromPlayer) <= 10f)
            {
                StartCoroutine(WaitAndSplash(0.7f));
            }
            
        }

    }
    IEnumerator WaitAndSplash(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        float distanceFromPlayer = PlayerController_Master.playerBody.transform.position.x - transform.position.x;

        if (Mathf.Abs(distanceFromPlayer) <= splashRange)
        {
            PlayerController_Statuses.instance.damageDeath(-0.2f);
            PlayerController_Statuses.instance.setDirty(true);
            EventDisplayManager.instance.DisplayMessage("Damn! My clothes are ruined.");

        }
    }

}
