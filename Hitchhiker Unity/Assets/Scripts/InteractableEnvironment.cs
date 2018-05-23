using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableEnvironment : MonoBehaviour {

    //List of potential drops from interaction
    [SerializeField]
	protected GameObject[] itemDrops;

	//If the object has been interacted with
	public bool used = false;

	//Reference to the player object
	[SerializeField]
	private GameObject SpawnPoint;

    public GameObject _player;
    public GameObject _inventory;

    //Offset to place object above player model
    public float yOffset = 2;

	//Delay in seconds before object is destroyed
	public int delay = 5;

	private float transformXAdjust=0.01f;
	private Vector3 _transformOriginal;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
        //_inventory.SetActive(false);
		_transformOriginal=this.transform.position;
        SpawnPoint = PlayerController_Master.playerBody;
    }


    // Update is called once per frame
    void Update () {
		
		//Check if hit by ray trace from camera to mouse
		if(PlayerController_ClickRay.isMouseHover && !used){
            

			if(PlayerController_ClickRay.hit.transform == transform){

				transform.position = new Vector3 (_transformOriginal.x+Mathf.Sin (Time.time * 10)*0.1f, transform.position.y, transform.position.z);

				//When mouse is pressed
				if(Input.GetMouseButtonDown(0)){
					//Mark as used
					used = true;
					Destroy(transform.GetChild(0).gameObject);

					// REMEBER TO REMOVE after first playable
					//_player.GetComponent<PlayerController_Master>().hitchhikingAllowed = true;

					//Get random gameobject from potential drops list
					GameObject drop = itemDrops[0];// itemDrops[Random.Range(0, itemDrops.Length)];
                    _inventory.GetComponent<Scr_Inventory>().addFoodItem(drop);


                    //Get the player model location
                    Vector3 loc = SpawnPoint.transform.position;
					//Translate up by yOffset Units
					loc.y += yOffset;

					//Create game object above players head
					GameObject instance = Instantiate(drop, loc, SpawnPoint.transform.rotation);

					//Set the parent of the game object to the player
					//This ensures the object remains above the players head
					instance.transform.SetParent(SpawnPoint.transform);

					//Destroy the gameobject after 5 seconds
					Destroy(instance, delay);
				}
			}
			else
			{
				this.transform.position = _transformOriginal;
			}
		}
	}
}
