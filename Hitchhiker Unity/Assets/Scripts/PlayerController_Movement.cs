using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Movement : MonoBehaviour {

	private PlayerController_Master player;

    public Sprite thumbsUpSprite;
    public Sprite thumbsDownSprite;

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
	}

	void Update () {
		transform.position -= new Vector3(player.baseSpeed * _moveMod * _hitchHikeMod * Time.deltaTime, 0.0f, 0.0f);
	}

	public void toggleMove(Text buttonText) {
		player.isMoving = !player.isMoving;
        if (player.isMoving) {
            _moveMod = MOVING;
            buttonText.text = "Rest";
        }
        else {
            _moveMod = STOPPED;
            buttonText.text = "Walk";
        }
	}

	public void toggleHitchHike(Image buttonSprite) {
		player.isHitchhiking = !player.isHitchhiking;
        if (player.isHitchhiking) {
            _hitchHikeMod = player.hitchHikingSpeedMod;
            buttonSprite.sprite = thumbsUpSprite;
        }
        else {
            _hitchHikeMod = NOTHITCHHIKING;
            buttonSprite.sprite = thumbsDownSprite;
        }
	}
}
