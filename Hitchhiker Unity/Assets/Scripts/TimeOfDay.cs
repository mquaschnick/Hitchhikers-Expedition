using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour {
    [Header("Rain")]
    public GameObject rainObject;
    private ParticleSystem rainSystem;
    private AudioSource rainAudio;

    public float rainDuration;
    public float rainInterval;
    public float rainTransition;

    private float maxRainVolume;
    private float rainTimer;
    private bool isRaining = false;


	// Use this for initialization
	void Start () {
        rainSystem = rainObject.GetComponent<ParticleSystem>();
        rainAudio = rainObject.GetComponent<AudioSource>();

        maxRainVolume = rainAudio.volume;
        rainAudio.volume = 0.0f;
        rainTimer = rainTransition;
    }
	
	// Update is called once per frame
	void Update () {
        rainTimer += Time.deltaTime;
        if (isRaining)
        {
            if (rainTimer < rainDuration)
            {
                float invereLerp = Mathf.InverseLerp(0f, rainTransition, rainTimer);
                rainAudio.volume = Mathf.Lerp(0.0f, maxRainVolume, invereLerp);
                var emit = rainSystem.emission;
                emit.rateOverTime = Mathf.Lerp(0.0f, 100f, invereLerp);
            }
            else
            {
                StopRain();
            }
        }
        else
        {
            if (rainTimer < rainInterval)
            {
                float invereLerp = Mathf.InverseLerp(0f, rainTransition, rainTimer);
                rainAudio.volume = Mathf.Lerp(maxRainVolume, 0.0f, invereLerp);
                var emit = rainSystem.emission;
                emit.rateOverTime = Mathf.Lerp(100f, 0f, invereLerp);
            }
            else
            {
                StartRain();
            }
        }
	}

    void StartRain()
    {
        isRaining = true;
        rainTimer = 0f;
        rainSystem.Play();
        rainAudio.Play();
    }
    void StopRain()
    {
        isRaining = false;
        rainTimer = 0f;
    }
}
