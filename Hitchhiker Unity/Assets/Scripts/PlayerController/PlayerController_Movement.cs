using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Movement : MonoBehaviour {

	private PlayerController_Master player;

    public Sprite thumbsUpSprite;
    public Sprite thumbsDownSprite;

    public Sprite walkingSprite;
    public Sprite restingSprite;

    private Image thumbSprite;
    private Image walkSprite;

    // Private Variables
    private float _moveMod = 0.0f;
	private float _hitchHikeMod = 1.0f;

	// Private Constants
	private const float MOVING = 1.0f;
	private const float STOPPED = 0.0f;
	private const float NOTHITCHHIKING = 1.0f;

	void Start () {
		player = GetComponent<PlayerController_Master>();
		player.isMoving = false;
		player.isHitchhiking = false;
        thumbSprite = GameObject.FindGameObjectWithTag("ThumbButton").GetComponent<Image>();
        walkSprite = GameObject.FindGameObjectWithTag("WalkButton").GetComponent<Image>();
    }

	void Update () {
		transform.position -= new Vector3(player.baseSpeed * _moveMod * player.injuredAffect * _hitchHikeMod * Time.deltaTime, 0.0f, 0.0f);
	}

	public void toggleMove() {
		player.isMoving = !player.isMoving;
        if (player.isMoving && !player.isInCar) {
            _moveMod = MOVING;
            walkSprite.sprite = walkingSprite;
        }
        else {
            _moveMod = STOPPED;
            walkSprite.sprite = restingSprite;
        }
	}

	public void toggleHitchHike() {
		player.isHitchhiking = !player.isHitchhiking;
        if (player.isHitchhiking && !player.isInCar) {
            _hitchHikeMod = player.hitchHikingSpeedMod;
            thumbSprite.sprite = thumbsUpSprite;
        }
        else {
            _hitchHikeMod = NOTHITCHHIKING;
            thumbSprite.sprite = thumbsDownSprite;
        }
	}

    public void getInCar() {
        player.isInCar = true;

        player.isHitchhiking = false;
        _hitchHikeMod = NOTHITCHHIKING;
        thumbSprite.sprite = thumbsDownSprite;

        player.isMoving = false;
        _moveMod = STOPPED;
        walkSprite.sprite = restingSprite;
    }

    public void getOutCar() {
        player.isInCar = false;
    }
}
