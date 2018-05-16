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

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
        //_inventory.SetActive(false);
    }


    // Update is called once per frame
    void Update () {

		//When mouse is pressed
		if(Input.GetMouseButtonDown(0)){
			//Variable to store the result of the Raycast
			RaycastHit hit;
			//Ray from the camera to the mouse pointer
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			//Check if hit by ray trace from camera to mouse
			if (Physics.Raycast(ray, out hit)){
				//Check if already been interacted with
				if (!used && hit.transform == transform) {
					//Mark as used
					used = true;
                    Destroy(transform.GetChild(0).gameObject);

                    // REMEBER TO REMOVE after first playable
                    //_player.GetComponent<PlayerController_Master>().hitchhikingAllowed = true;

                    //Get random gameobject from potential drops list
                    GameObject drop = itemDrops[0];// itemDrops[Random.Range(0, itemDrops.Length)];
                    //_inventory.GetComponent<Scr_Inventory>().inventory[0, 0] = drop;
                    //_inventory.GetComponent<Scr_Inventory>().updateButtons();
                    //_inventory.SetActive(true);
                    _inventory.GetComponent<Scr_Inventory>().buttons[0, 0].transform.GetChild(0).GetComponent<Text>().text = "Berry";
                    _inventory.GetComponent<Scr_Inventory>().buttons[0, 0].onClick.AddListener(drop.GetComponent<Scr_FoodItem>().consumeItem);
                    //_inventory.SetActive(false);


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
		}
	}
}
