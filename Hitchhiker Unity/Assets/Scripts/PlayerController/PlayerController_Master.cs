using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController_Master : MonoBehaviour {

    public GameObject shopScreen;

	// Public Variables
    public static GameObject playerBody;

	public float baseSpeed = 3.0f;
    public float injuredAffect = 1.0f;
	public float hitchHikingSpeedMod = 0.5f;
    public float hunger = 0.6f; // 0 starving, 1 full
    public float starveRate = -0.0001f;
	public float thirst = 0.6f; // 0 dehydrated, 1 full
	public float thirstRate = -0.0001f;
    public float D34TH = 1.0f; // 0 starving, 1 full
    public float D34THRate = -0.0002f;
	public float weather = 1.0f;
	public float population = 0.5f;
	public bool isMoving;
	public bool isHitchhiking;
    public bool isInCar;
    public bool isDirty;

    private void Awake() {
        playerBody = transform.GetChild(1).gameObject;
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }



    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "EndOfLevel") {
            SceneManager.LoadScene("Success");
        }
        else if(other.gameObject.tag == "Shop") {
            PlayerController_Movement moveScript = GetComponent<PlayerController_Movement>();
            moveScript.setMove(false);
            moveScript.setHitchHike(false);

            shopScreen.GetComponent<Shop>().open();
        }
    }

}
