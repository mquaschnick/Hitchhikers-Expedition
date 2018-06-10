using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController_Master))]
public class PlayerController_Movement : MonoBehaviour {
    public List<Animator> AnimatorList = new List<Animator>();
    public Animator[] characterAnimators;
    
    public RuntimeAnimatorController MaleAnimator, FemaleAnimator;

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
        SetupAnimList(characterAnimators);
        CheckMaleOrFemale();
        thumbSprite = GameObject.FindGameObjectWithTag("ThumbButton").GetComponent<Image>();
        walkSprite = GameObject.FindGameObjectWithTag("WalkButton").GetComponent<Image>();
    }

	void Update () {
		transform.position -= new Vector3(player.baseSpeed * _moveMod * player.injuredAffect * _hitchHikeMod * Time.deltaTime, 0.0f, 0.0f);
	}

    public void setMove( bool isOn ) {
        player.isMoving = isOn;

        if(isOn) {
        foreach (Animator anim in characterAnimators)
        {
            anim.SetInteger("AnimState", 1);
        }
        walkSprite.sprite = walkingSprite;
        _moveMod = MOVING;
        } else {
        foreach (Animator anim in characterAnimators)
        {
            anim.SetInteger("AnimState", 0);
        }
        walkSprite.sprite = restingSprite;
        _moveMod = STOPPED;
        }
    }

	public void toggleMove() {
		player.isMoving = !player.isMoving;
        if (player.isMoving && !player.isInCar) {
            _moveMod = MOVING;
            walkSprite.sprite = walkingSprite;
            foreach(Animator anim in characterAnimators)
            {
                anim.SetInteger("AnimState", 1);
            }
        }
        else {
            _moveMod = STOPPED;
            walkSprite.sprite = restingSprite;
            foreach (Animator anim in characterAnimators)
            {
                anim.SetInteger("AnimState", 0);
            }
        }
	}

    public void setHitchHike( bool isOn ) {
        player.isHitchhiking = isOn;
        foreach (Animator anim in characterAnimators)
        {
            anim.SetBool("Hitchhike", isOn);
        }

        if(isOn) {
            thumbSprite.sprite = thumbsUpSprite;
            _hitchHikeMod = player.hitchHikingSpeedMod;
        } else {
            thumbSprite.sprite = thumbsDownSprite;
            _hitchHikeMod = NOTHITCHHIKING;
        }
    }

	public void toggleHitchHike() {
		player.isHitchhiking = !player.isHitchhiking;
        if (player.isHitchhiking && !player.isInCar) {
            _hitchHikeMod = player.hitchHikingSpeedMod;
            thumbSprite.sprite = thumbsUpSprite;

            foreach (Animator anim in characterAnimators)
            {
                anim.SetBool("Hitchhike", true);
            }
        }
        else {
            _hitchHikeMod = NOTHITCHHIKING;
            thumbSprite.sprite = thumbsDownSprite;
            foreach (Animator anim in characterAnimators)
            {
                anim.SetBool("Hitchhike", false);
            }
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

        PlayerController_Master.playerBody.SetActive(false);

        foreach (Animator anim in characterAnimators)
        {
            anim.SetBool("Hitchhike", false);
            anim.SetInteger("AnimState", 0);
        }
    }

    public void getOutCar() {
        player.isInCar = false;
        PlayerController_Master.playerBody.SetActive(true);
    }

    public void SetupAnimList(Animator[] playerAnims)
    {
        AnimatorList = new List<Animator>();
        foreach(Animator playerAnim in playerAnims)
        {
            AnimatorList.Add(playerAnim);
        }
    }
    public void CheckMaleOrFemale()
    {
        if (SavedPlayerStats.IsFemale == false)
        { 
            AnimatorList[0].runtimeAnimatorController = MaleAnimator;
        }
        else if (SavedPlayerStats.IsFemale == true)
        {
            AnimatorList[0].runtimeAnimatorController = FemaleAnimator;
        }
    }
}
