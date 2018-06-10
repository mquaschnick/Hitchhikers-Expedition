using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPlayerStats : MonoBehaviour {

    public static bool IsFemale = false;
    //public static bool GameBegun;
    public static SavedPlayerStats Instance;

    [Tooltip("After player goes through the opening bits of the game, this scene is where begin button in character select will take you.")]
    public static string StartingGameLevelSceneName;

    //public GameObject playerObj;
   

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
            Debug.Log("Instance Set.");
        }
        else if (Instance !=this)
        {
            Debug.Log("DontDestroy is DEstroyed");
            Destroy(this.gameObject);
            return;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
